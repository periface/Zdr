(function () {
    angular.module('app').factory('geoCoder', [

    function () {

        var geoCoderInstance;
        var codeLatLngForState = function (lat, lng, callback) {
            var city;
            // ReSharper disable once UseOfImplicitGlobalInFunctionScope
            var latlng = new google.maps.LatLng(lat, lng);
            geoCoderInstance.geocode({ 'latLng': latlng }, function (results, status) {
                // ReSharper disable once UseOfImplicitGlobalInFunctionScope
                if (status === google.maps.GeocoderStatus.OK) {
                    if (results[1]) {
                        //formatted address
                        //alert(results[0].formatted_address);
                        //find country name
                        for (var i = 0; i < results[0].address_components.length; i++) {
                            for (var b = 0; b < results[0].address_components[i].types.length; b++) {

                                //there are different types that might hold a city admin_area_lvl_1 usually does in come cases looking for sublocality type will be more appropriate
                                if (results[0].address_components[i].types[b] === "administrative_area_level_1") {
                                    //this is the object you are looking for
                                    city = results[0].address_components[i];
                                    break;
                                }
                            }
                        }
                        //city data
                        callback(null, city);
                    } else {
                        console.error("No results found");
                    }
                } else {
                    callback(status, null);
                }
            });
        }
        var codeLatLngForBoth = function (lat, lng, callback) {
            var locationData = {
                City: "",
                State: ""
            };
            // ReSharper disable once UseOfImplicitGlobalInFunctionScope
            var latlng = new google.maps.LatLng(lat, lng);
            geoCoderInstance.geocode({ 'latLng': latlng }, function (results, status) {
                // ReSharper disable once UseOfImplicitGlobalInFunctionScope
                if (status === google.maps.GeocoderStatus.OK) {
                    if (results[1]) {
                        //formatted address
                        //alert(results[0].formatted_address);
                        //find country name
                        for (var i = 0; i < results[0].address_components.length; i++) {
                            for (var b = 0; b < results[0].address_components[i].types.length; b++) {

                                //there are different types that might hold a city admin_area_lvl_1 usually does in come cases looking for sublocality type will be more appropriate
                                if (results[0].address_components[i].types[b] === "administrative_area_level_1") {
                                    //this is the object you are looking for
                                    locationData.State = results[0].address_components[i];
                                } else {
                                    if (results[0].address_components[i].types[b] === "administrative_area_level_2") {
                                        locationData.City = results[0].address_components[i];
                                    }
                                }
                            }
                        }
                        //city data
                        callback(null, locationData);
                    } else {
                        console.error("No results found");
                    }
                } else {
                    callback(status, null);
                }
            });
        }
        var codeLatLng = function (lat, lng, callback) {
            var city;
            // ReSharper disable once UseOfImplicitGlobalInFunctionScope
            var latlng = new google.maps.LatLng(lat, lng);
            geoCoderInstance.geocode({ 'latLng': latlng }, function (results, status) {
                // ReSharper disable once UseOfImplicitGlobalInFunctionScope
                if (status === google.maps.GeocoderStatus.OK) {
                    if (results[1]) {
                        //formatted address
                        //alert(results[0].formatted_address);
                        //find country name
                        for (var i = 0; i < results[0].address_components.length; i++) {
                            for (var b = 0; b < results[0].address_components[i].types.length; b++) {

                                //there are different types that might hold a city admin_area_lvl_1 usually does in come cases looking for sublocality type will be more appropriate
                                if (results[0].address_components[i].types[b] === "administrative_area_level_2") {
                                    //this is the object you are looking for
                                    city = results[0].address_components[i];
                                    break;
                                }
                            }
                        }
                        //city data
                        callback(null, city);
                    } else {
                        console.error("No results found");
                    }
                } else {
                    callback(status, null);
                }
            });
        }
        function formatCurrentPosition(position, scope, callback) {
            var lat;
            var lng;
            if (position.coords) {
                lat = position.coords.latitude;
                lng = position.coords.longitude;
            } else {
                lat = position.lat;
                lng = position.lng;
            }
            switch (scope) {
                case "State":
                    codeLatLngForState(lat, lng, function (error, result) {
                        if (!error) {
                            callback(null, result);
                        } else {
                            callback(error, null);
                        }
                    });
                    break;
                case "City":
                    codeLatLng(lat, lng, function (error, result) {
                        if (!error) {
                            callback(null, result);
                        } else {
                            callback(error, null);
                        }
                    });
                default:
                    codeLatLngForBoth(lat, lng, function (error, result) {
                        if (!error) {
                            callback(null, result);
                        } else {
                            callback(error, null);
                        }
                    });
                    break;
            }

        }
        this.getCity = function (position, geoCoder, callback) {
            geoCoderInstance = geoCoder;
            formatCurrentPosition(position, "City", function (error, result) {
                if (!error) {
                    callback(null, result);
                } else {
                    callback(error, null);
                }
            });
        }
        this.getState = function (position, geoCoder, callback) {
            geoCoderInstance = geoCoder;
            formatCurrentPosition(position, "State", function (error, result) {
                if (!error) {
                    callback(null, result);
                } else {
                    callback(error, null);
                }
            });
        }
        this.getCityAndState = function (position, geoCoder, callback) {
            geoCoderInstance = geoCoder;
            formatCurrentPosition(position, "Both", function (error, result) {
                if (!error) {
                    callback(null, result);
                } else {
                    callback(error, null);
                }
            });
        }
        this.getCityAndStateByCoords = function (lat, lng, geoCoder, callback) {
            geoCoderInstance = geoCoder;
            var position = {
                lat: lat,
                lng: lng
            }
            formatCurrentPosition(position, "Both", function (error, result) {
                if (!error) {
                    callback(null, result);
                } else {
                    callback(error, null);
                }
            });
        }
        return {
            getCity: this.getCity,
            getState: this.getState,
            getBoth: this.getCityAndState,
            getBothByCoords: this.getCityAndStateByCoords
        }
    }]);
})();