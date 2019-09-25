import { BrowserModujle}

var testApp = Angular

module('testModule', []);
var url = 'https://localhost:5001/api/bids'
 

    $http.post(url, config, data)
        .success(function (data, status, headers, config) {
            $scope.post(data);
        })
        .error(function (data, status, headers, config) {
            $scope.responseDetails = "data" + data +
                "status" + status +
                "headers" + headers + "config" + config;

        });
});
 


