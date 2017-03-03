var GlobalController = function ($http) {
    var globalCtrl = this;

    globalCtrl.openRecord = function (url) {
        window.location.href = url;
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

GlobalController.$inject = ['$http'];