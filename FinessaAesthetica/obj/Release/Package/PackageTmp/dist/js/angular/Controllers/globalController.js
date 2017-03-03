var GlobalController = function ($http, dataService) {
    var globalCtrl = this;

    globalCtrl.openRecord = function (url) {
        window.location.href = url;
    }

    globalCtrl.initializeData = function (url, controller) {
        dataService.get(url).then(function (data) {
            var obj = [];

            for (var i = 0; i < data.length; i++) {
                obj.push({ IsSelected: false });
            }

            controller.List = angular.merge({}, data, obj);
        });
    }

    globalCtrl.deleteRecord = function (records, url) {

        if (confirm('Are you sure you want to delete this record?')) {

            $http.delete(url)
                    .then(function (result) {
                        alert('record deleted!');
                    })
                    .error(function (result) {
                        alert("An Error has occured while Deleting ! " + result.Message);
                    });
        }
    }
};

GlobalController.$inject = ['$http', 'dataService'];