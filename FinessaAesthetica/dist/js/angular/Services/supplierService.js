var SupplierFactory = function ($http) {

    var SupplierService = {};

    SupplierService.get = function () {
        return $http({ method: "GET", url: "/api/Suppliers/" }).then(function (result) {
            return result.data;
        });
    }

    SupplierService.update = function (supplier) {
        return $http.put('/api/Suppliers/' + supplier.SupplierId, supplier)
               .error(function (result) {
                   alert("An Error has occured while updating Spending Logs! " + result.Message);
               });
    }

    SupplierService.add = function (supplier) {
        return $http.post('/api/Suppliers/', supplier)
              .error(function (result) {
                  alert("An Error has occured while adding Spending Logs! " + result.Message);
              });
    }

    SupplierService.delete = function (id) {

        return $http.delete('/api/Suppliers/' + id)
              .error(function (result) {
                  alert("An Error has occured while Deleting ! " + result.Message);
              });
    }

    return SupplierService;
}

SupplierFactory.$inject = ['$http'];