(function () {
    var controllerId = 'app.views.createZone';
    angular.module('app').controller(controllerId, [
        '$scope', function ($scope) {
            var vm = this;
            // logic...
            
            var init = function () {

            }
            vm.zdr = {};
            vm.addZdr = function() {
                console.log(vm.zdr);
            }
            init();

        }
    ]);
})();