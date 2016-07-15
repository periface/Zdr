(function () {
    var controllerId = 'app.views.createZone';
    angular.module('app').controller(controllerId, [
        '$scope', '$uibModalInstance', 'Upload', 'userLocation', 'currentCenter', function ($scope, uibModalInstance, upload, userLocation, currentCenter) {
            var vm = this;
            // logic...

            var init = function() {

            };
            console.log(currentCenter);
            vm.files = [];
            vm.zdr = {};
            vm.zdr.City = userLocation.City.short_name;
            vm.zdr.CityLongName = userLocation.City.long_name;

            vm.zdr.State = userLocation.State.short_name;
            vm.zdr.StateLongName = userLocation.State.long_name;
            vm.zdr.Country = userLocation.Country.short_name;
            vm.zdr.CountryLongName = userLocation.Country.long_name;
            vm.zdr.Latitude = currentCenter.latitude;
            vm.zdr.Longitude = currentCenter.longitude;

            vm.percent = 0;
            vm.addZdr = function() {
                upload.upload({
                    url: "/Home/CreateZone",
                    data: { files: vm.files, Zdr: vm.zdr }
                }).then(function(data) {
                    uibModalInstance.close(data);
                }, function(response) {
                    console.log(response);
                }, function(evt) {
                    vm.percent = parseInt(100.0 * evt.loaded / evt.total);
                    console.log(vm.percent);
                });
            };
            init();
            vm.cancel = function () {
                uibModalInstance.dismiss();
            };
        }

    ]);
})();