var SupplierController = function ($scope, dataService) {

    var supplierCtrl = this;
    supplierCtrl.isAllRecordSelected = false;

    supplierCtrl.initData = function () {
        dataService.get('/api/Supplier/').then(function (data) {
            var obj = [];

            for (var i = 0; i < data.length; i++) {
                obj.push({ IsSelected: false });
            }

            supplierCtrl.supplierList = angular.merge({}, data, obj);
        });
    }

    supplierCtrl.selectAll = function () {
        var result = supplierCtrl.isAllRecordSelected;

        if (result == false) {
            result == true;
            supplierCtrl.isAllRecordSelected = result;
        }
        else {
            result == false;
            supplierCtrl.isAllRecordSelected = result;
        }

        angular.forEach(supplierCtrl.supplierList, function (item, index) {
            item.IsSelected = result;
        });
    }
    supplierCtrl.selectSingle = function (supplierItem) {
        if (supplierItem.IsSelected == true) {
            supplierItem.IsSelected = false;
        }
        else {
            supplierItem.IsSelected = true;
        }
    }
    supplierCtrl.selectRow = function (supplierItem) {
        supplierItem.IsSelected = true;
        supplierCtrl.isAllRecordSelected = false;

        angular.forEach(supplierCtrl.supplierList, function (item, index) {

            if (supplierItem.SupplierId != item.SupplierId) {
                item.IsSelected = false;
            }

        });
    }


    supplierCtrl.massDelete = function () {
        var list = []

        angular.forEach(supplierCtrl.supplierList, function (item, index) {

            if (item.IsSelected == true) {
                list.push(item);
            }

        });

        if (list.length <= 0) {
            alert('select a record first.');
            return;
        }


        if (confirm('Are you sure you want to delete this record?')) {
            var json = JSON.stringify(list);
                        
            $.ajax({
                type: 'DELETE',
                url: '/api/Supplier/DeleteSuppliers',
                contentType: "application/json; charset=utf-8",
                async: true,
                cache: false,
                data: json
            }).then(function () {
                alert('succesfully saved!');
                window.location.href = "/PurchaseOrder/"
            });
                     
        }
    }

    supplierCtrl.alertFunction = function () {
        alert('hello tom');
    }

    supplierCtrl.changeStatus = function () {

    }


};

SupplierController.$inject = ['$scope', 'dataService'];