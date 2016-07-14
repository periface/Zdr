(function () {
    var controllerId = 'app.views.home';
    angular.module('app').controller(controllerId, [
        '$scope', 'uiGmapGoogleMapApi', '$filter', "geoCoder", '$uibModal', function ($scope, uiGmapGoogleMapApi, $filter, geoCoder, $uibModal) {
            var vm = this;
            vm.showError = true;

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
                City: "Detectando..."
            }
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
                        console.log("GetStateResults");
                        console.log(result);
                        vm.userLocation.State = result.State;
                        vm.userLocation.City = result.City;
                    });
                }, function (error) {
                    alert("No fue posible determinar su ubicación");
                    vm.showError = true;
                    console.log(error);
                });
            });
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
            vm.setMarker = function (data) {
                //var centerMarker = $filter('filter')(vm.markers, { id: 'CenterMarker' }, true);
                //if (centerMarker.length) {
                //    centerMarker[0].coords.latitude = data.center.lat();
                //    centerMarker[0].coords.longitude = data.center.lng();
                //}
                //console.log(centerMarker);
               

                geoCoder.getBothByCoords(data.center.lat(), data.center.lng(),geoCoderInstance, function (error, result) {
                    console.log(result);
                    console.log(error);
                    vm.userLocation.State = result.State;
                    vm.userLocation.City = result.City === "" ? "Ciudad no detectada" : result.City;
                });
            }
            var placeMarker = function (lat, lng) {

            }
            vm.markers = [];
            var init = function () {

            }
            init();
        }
    ]);
})();