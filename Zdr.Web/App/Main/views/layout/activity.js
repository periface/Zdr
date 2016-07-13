(function () {
    var controllerId = 'app.views.activity';
    angular.module('app').controller(controllerId, [
        '$scope', function ($scope) {
            var vm = this;
            vm.activity = [];
            var init = function () {
                vm.activity.push({
                    user: "User1",
                    content:"Lorem ipsum dolor sit ...",
                    hasImage: false,
                    hasVideo: true,
                    pointId: true
                });
            }
            init();
        }]);
})();