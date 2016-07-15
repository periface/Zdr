(function () {
    var controllerId = 'app.views.home';
    angular.module('app').controller(controllerId, [
        '$scope', 'uiGmapGoogleMapApi', '$filter', "geoCoder", '$uibModal', 'abp.services.app.riskZone', function ($scope, uiGmapGoogleMapApi, $filter, geoCoder, $uibModal,zoneService) {
            var vm = this;

            var prevCity;
            vm.showError = true;
            vm.changeCenter = function(data) {
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
                vm.modal =$uibModal.open({
                    templateUrl: '/App/Main/views/home/createZone.cshtml',
                    controller: 'app.views.createZone as vm',
                    backdrop: 'static',
                    resolve: {
                        userLocation: function () {
                            return vm.userLocation;
                        },
                        currentCenter:function() {
                            return vm.map.center;
                        }
                    }
                });
                vm.modal.result.then(function(marker) {
                    console.log(marker);
                });

            };
            vm.setMarker = function(data) {
                geoCoder.getBothByCoords(data.center.lat(), data.center.lng(), geoCoderInstance, function(error, result) {
                    vm.userLocation.State = result.State;
                    vm.userLocation.City = result.City === "" ? "Ciudad no detectada" : result.City;
                    getZonesByCity(vm.userLocation.City.short_name);
                });
            };
            var placeMarker = function(id,lat, lng) {
                vm.markers.push({
                    id:id,
                    coords: {
                        latitude: lat,
                        longitude:lng
                    },
                    options: { draggable: false },
                    events: {
                        click:function() {
                            alert("Click");
                        }
                    }
                });
                console.log(vm.markers);
            };
            var getZonesByCity = function (city) {
                if (city !== prevCity) {

                    vm.markers = [];
                    zoneService.getRiskZonesByCity(city).then(function(response) {
                        var markers = response.data.positions;
                        console.log(markers);
                        for (var i = 0; i < markers.length; i++) {
                            console.log("Trigger");
                            placeMarker(markers[i].id, markers[i].latitude, markers[i].longitude);
                        }
                    });
                }
                prevCity = city;
            }
            vm.markers = [];

            var init = function() {
                uiGmapGoogleMapApi.then(function () {
                    geoCoderInstance = new google.maps.Geocoder();
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