var ServiceFactory = function ($http) {

    var Service = {};

    Service.get = function (url) {
        return $http({ method: "GET", url: url }).then(function (result) {
            return result.data;
        });
    }

    Service.update = function (supplier) {
        return $http.put('/api/Supplier/' + supplier.SupplierId, supplier)
               .error(function (result) {
                   alert("An Error has occured while updating Spending Logs! " + result.Message);
               });
    }

    Service.add = function (supplier) {
        return $http.post('/api/Supplier/', supplier)
              .error(function (result) {
                  alert("An Error has occured while adding Spending Logs! " + result.Message);
              });
    }

    Service.delete = function (id) {

        return $http.delete('/api/Supplier/' + id)
              .error(function (result) {
                  alert("An Error has occured while Deleting ! " + result.Message);
              });
    }

    Service.massDelete = function (records, url) {
        return $http({ method: "DELETE", contentType: "application/json; charset=utf-8", url: url, data: { records: records } });
    }

    return Service;
}

ServiceFactory.$inject = ['$http'];