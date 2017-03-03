var ReceivingController = function ($http) {
    var receivingCtrl = this;
    receivingCtrl.isAllRecordSelected = false;

    receivingCtrl.itemList = [];

    receivingCtrl.list = [
        { Id: 4, Number: 'PO-00004', Remarks: 'Sample Data 4', Status: 'Approved', Supplier: 'Supplier-01', TotalAmount: 'P2, 000', TotalQuantity: 5, IsSelected: false },
        { Id: 5, Number: 'PO-00005', Remarks: 'Sample Data 5', Status: 'Pending', Supplier: 'Supplier-101', TotalAmount: 'P2, 000', TotalQuantity: 5, IsSelected: false }
    ];

    receivingCtrl.receivePurcaseOrder = function () {
        var list = []

        angular.forEach(receivingCtrl.list, function (item, index) {

            if (item.IsSelected == true) {
                list.push(index);
            }

        });

        if (list.length <= 0) {
            alert('select a record first.');
            return;
        }

        var indexes = [];

        angular.forEach(indexes, function (item, index) {
            receivingCtrl.list.splice(item, 1);
        });
        
        alert('Update Successful!');
        window.location.href = "/MainInventory/";
    }
    
    receivingCtrl.selectAll = function () {
        var result = receivingCtrl.isAllRecordSelected;

        if (result == false) {
            result == true;
            receivingCtrl.isAllRecordSelected = result;
        }
        else {
            result == false;
            receivingCtrl.isAllRecordSelected = result;
        }

        angular.forEach(receivingCtrl.list, function (item, index) {
            item.IsSelected = result;
        });
    }
    receivingCtrl.selectSingle = function (item) {
        if (item.IsSelected == true) {
            item.IsSelected = false;
        }
        else {
            item.IsSelected = true;
        }
    }

    receivingCtrl.selectRow = function (data) {
        data.IsSelected = true;
        data.isAllRecordSelected = false;

        angular.forEach(receivingCtrl.list, function (item, index) {

            if (data.Id != item.Id) {
                item.IsSelected = false;
            }

        });
    }

    receivingCtrl.deleteRecord = function (index) {
        if (confirm('Are you sure you want to delete this record?')) {
            receivingCtrl.list.splice(index, 1);
        }
    }
};

ReceivingController.$inject = ['$http'];