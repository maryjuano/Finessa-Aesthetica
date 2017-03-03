(function () {
    'use strict';

    angular.module('globalModule', [])
    .controller('globalCtrl', GlobalController)
    .controller('supplierCtrl', SupplierController)
    .factory('supplierService', ServiceFactory);

})();