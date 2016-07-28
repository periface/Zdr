(function () {
    var controllerId = 'app.views.home';
    angular.module('app').controller(controllerId, [
        '$scope', 'uiGmapGoogleMapApi', '$filter', "geoCoder", '$uibModal', 'abp.services.app.riskZone', 'uiGmapIsReady', function ($scope, uiGmapGoogleMapApi, $filter, geoCoder, $uibModal, zoneService, uiGmapIsReady) {
            var vm = this;
            var map;
            var mapIsReady;
            var prevCity;
            vm.showError = true;
            vm.changeCenter = function (data) {
                vm.map.center.latitude = data.center.lat();
                vm.map.center.longitude = data.center.lng();
            }
            var geoCoderInstance;
            //Home logic...
            vm.map = {
                center: {
                    latitude: 25,
                    longitude: -17
                },
                zoom: 8
            };
            var currentPosition;
            vm.userLocation = {
                State: "Detectando...",
                City: "Detectando...",
                Country: "Detectando..."
            };

            vm.modal = {};
            vm.createZdrModal = function () {
                vm.modal = $uibModal.open({
                    templateUrl: '/App/Main/views/home/createZone.cshtml',
                    controller: 'app.views.createZone as vm',
                    backdrop: 'static',
                    resolve: {
                        userLocation: function () {
                            return vm.userLocation;
                        },
                        currentCenter: function () {
                            return vm.map.center;
                        }
                    }
                });
                vm.modal.result.then(function (marker) {
                    prevCity = "";
                    abp.notify.success("Publicación agregada", "Pulicación");
                    getZonesByCity(vm.userLocation.CityShortName);
                });

            };
            vm.setMarker = function (data) {
                geoCoder.getBothByCoords(data.center.lat(), data.center.lng(), geoCoderInstance, function (error, result) {
                    if (!result && error) {
                        vm.userLocation.State = "No detectado";
                        vm.userLocation.City = "No detectado";
                    } else {
                        vm.userLocation.State = result.State;
                        vm.userLocation.City = result.City === "" ? "Ciudad no detectada" : result.City;
                        getZonesByCity(vm.userLocation.City.short_name);
                        getZonesByMapPosition();
                    }
                });
            };
            var placeMarker = function (id, lat, lng) {
                vm.markers.push({
                    id: id,
                    coords: {
                        latitude: lat,
                        longitude: lng
                    },
                    options: { draggable: false },
                    events: {
                        click: function () {
                            alert("Click");
                        }
                    }
                });
            };
            //In mobile devices this should be cached.
            var getZonesByCity = function (city) {
                if (city !== prevCity) {
                    vm.markers = [];
                    zoneService.getRiskZonesByCity(city).then(function (response) {
                        var markers = response.data.positions;
                        for (var i = 0; i < markers.length; i++) {
                            placeMarker(markers[i].id, markers[i].latitude, markers[i].longitude);
                        }
                    });
                }
                prevCity = city;
            };
            var toRad = function (x) {
                return x * Math.PI / 180;
            }
            var getDistanceBetweenPoints = function (pos1, pos2, units) {
                var earthRadius = {
                    miles: 3958.8,
                    km: 6371
                };
                var r = earthRadius[units || 'miles'];
                var lat1 = pos1.lat;
                var lon1 = pos1.lng;
                var lat2 = pos2.lat;
                var lon2 = pos2.lng;

                var dLat = toRad((lat2 - lat1));
                var dLon = toRad((lon2 - lon1));
                var a = Math.sin(dLat / 2) * Math.sin(dLat / 2) +
                    Math.cos(toRad(lat1)) * Math.cos(toRad(lat2)) *
                    Math.sin(dLon / 2) *
                    Math.sin(dLon / 2);
                var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
                var d = r * c;

                return d;

            };
            var getBoundingRadius = function (center, bounds) {
                return getDistanceBetweenPoints(center, bounds.northeast, 'km');
            }
            var getZonesByMapPosition = function () {
                uiGmapIsReady.promise(1).then(function (instances) {
                    instances.forEach(function (inst) {
                        map = inst.map;
                        //var uuid = map.uiGmap_id;
                        //var mapInstanceNumber = inst.instance; // Starts at 1.
                        var center = map.getCenter();
                        var bounds = map.getBounds();
                        var zoom = map.getZoom();
                        var centerNorm = {
                            lat: center.lat(),
                            lng: center.lng()
                        }
                        var boundsNorm = {
                            northeast: {
                                lat: bounds.getNorthEast().lat(),
                                lng: bounds.getNorthEast().lng()
                            },
                            southeast: {
                                lat: bounds.getSouthWest().lat(),
                                lng: bounds.getSouthWest().lng()
                            }
                        }

                        var boundingRadius = getBoundingRadius(centerNorm, boundsNorm);
                        var params = {
                            Center: centerNorm,
                            Bounds: boundsNorm,
                            Zoom: zoom,
                            BoundingRadius: boundingRadius
                        }
                        zoneService.getRiskZonesWithDistance(params).then(function(data) {
                            
                        });
                        mapIsReady = true;
                    });
                });
            }
            vm.markers = [];

            var init = function () {
                uiGmapGoogleMapApi.then(function (maps) {
                    getZonesByMapPosition();
                    geoCoderInstance = new maps.Geocoder();
                    navigator.geolocation.getCurrentPosition(function (position) {
                        currentPosition = position;
                        $scope.$apply(function () {
                            vm.map = {
                                center: {
                                    latitude: position.coords.latitude,
                                    longitude: position.coords.longitude
                                },
                                zoom: 15
                            };
                        });
                        geoCoder.getBoth(position, geoCoderInstance, function (error, result) {
                            vm.userLocation.State = result.State;
                            vm.userLocation.City = result.City;
                            vm.userLocation.Country = result.Country;
                            vm.userLocation.CityShortName = result.City.short_name;
                            getZonesByCity(result.City.short_name);
                        });
                    }, function (error) {
                        alert("No fue posible determinar su ubicación");
                        vm.showError = true;
                        console.log(error);
                    });
                });
            };
            init();
        }
    ]);
})();