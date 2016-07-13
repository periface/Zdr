(function() {
    var controllerId = 'app.views.home';
    angular.module('app').controller(controllerId, [
        '$scope', 'uiGmapGoogleMapApi', '$filter', function ($scope, uiGmapGoogleMapApi, $filter) {
            var vm = this;
            vm.showError = true;
            //Home logic...
            vm.map = {
                center: {
                    latitude: 25,
                    longitude: -17
                },
                zoom: 8
            };
            navigator.geolocation.getCurrentPosition(function(position) {
                vm.map = {
                    center: {
                        latitude: position.coords.latitude,
                        longitude: position.coords.longitude
                    },
                    zoom: 15
                };

            },function(error) {
                alert("No fue posible determinar su ubicación");
                vm.showError = true;
                console.log(error);
            });
            vm.setMarker = function (data) {
                //var centerMarker = $filter('filter')(vm.markers, { id: 'CenterMarker' }, true);
                //if (centerMarker.length) {
                //    centerMarker[0].coords.latitude = data.center.lat();
                //    centerMarker[0].coords.longitude = data.center.lng();
                //}
                //console.log(centerMarker);
            }
            var placeMarker = function(lat, lng) {
                
            }
            vm.markers = [];
            var init = function () {

            }
            init();

        }
    ]);
})();