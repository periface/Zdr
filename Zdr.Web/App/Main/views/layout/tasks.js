(function () {
    var controllerId = 'app.views.tasks';
    angular.module('app').controller(controllerId, [
        '$scope', function ($scope) {
            var vm = this;
            vm.taskQueue = [];

            //Layout logic...

            function randomPercentage() {
                return Math.floor((Math.random() * 100) + 1);
            }

            var init = function () {
                vm.taskQueue.push({
                    content: "Lorem ipsum dolor sit",
                    percentageDone: randomPercentage()
                }, {
                    content: "Lorem ipsum dolor sit",
                    percentageDone: randomPercentage()
                }, {
                    content: "Lorem ipsum dolor sit",
                    percentageDone: randomPercentage()
                });
            }
            init();
        }]);
})();