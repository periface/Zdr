(function() {
    angular.module('app').factory('mapZoneService', ['abp.services.app.riskZone',function(riskZoneService) {
        
        var getZonesByCity = function(city) {
            
        }
        var getZonesByState = function(state) {
            
        }
        var getZonesByScreenPosition = function() {
            
        }

        return {
            getZonesByCity: this.getZonesByCity,
            getZonesByScreenPosition: this.getZonesByScreenPosition,
            getZonesByState: this.getZonesByState,
    }

    }]);
})();