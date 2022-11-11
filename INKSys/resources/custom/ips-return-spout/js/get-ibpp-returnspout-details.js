﻿var MainTable;
$(document).ready(function () {
    GetIPSReturnSpout();
    $('#btnUpdate').on('click', function () {
        UpdateReturnSpout();
    })
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
    function EndRequestHandler(sender, args) {
        GetIPSReturnSpout();
    }
});
$(document).on('click', 'button', function (e) {
    var elem = $(this);
    if (elem.hasClass('btn-update-row')) {
        var data = MainTable.row($(this).closest('tr')).data();
        var returnlotno = data[Object.keys(data)[0]];
        var partlotno = data[Object.keys(data)[1]];
        var amount = data[Object.keys(data)[2]];
        var cavityno = data[Object.keys(data)[3]];
        var boxno = data[Object.keys(data)[4]];
              
        $('#lbl_ReturnLotNo').text(returnlotno);
        $('#txt_PartLotNo').val(partlotno);
        $('#txt_Amount').val(amount);
        $('#txt_CavityNo').val(cavityno);
        $('#txt_BoxNo').val(boxno);
    }
});

function GetIPSReturnSpout(callback) {
    $.ajax({
        url: "IPS_ReturnSpout.aspx/GetIPSReturnSpout",
        type: "POST",
        data: "{}",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (e) {
            var d = JSON.parse(e.d);
            if (callback !== undefined) {
                callback(d);
            }
            var btnEdit = '<button type="button" data-toggle="modal" data-target="#ModalEdit" class="btn btn-sm btn-primary btn-update-row" title="Update"><i class="fas fa-edit"></i></button>';
            if (MainTable !== undefined && MainTable !== null) {
                MainTable.clear().destroy();
            }
            MainTable = $(".return-spout-table").DataTable({
                searching: true,
                paging: true,
                info: true,
                ordering: false,
                scrollX: true,
                scrollY: 400,

                data: d,
                columnDefs: [
                    { 'visible': false, 'targets': [] }
                ],
                columns: [
                    {
                        data: 'RETURNLOTNO', title: '', render: function (e) {
                            return btnEdit;
                        }
                    },
                    { data: 'RETURNLOTNO', title: 'RETURN LOT NO' },
                    { data: 'PARTLOTNO', title: 'PART LOT NO' },           
                    { data: 'AMOUNT', title: 'Amount' },
                    { data: 'CAVITYNO', title: 'Cavity Number' },
                    { data: 'BOXNO', title: 'Box Number' },
                    {
                        data: 'DATETIME', title: 'Date Created',
                        render: function (d) {
                            return moment(d).format("MM/DD/YYYY hh:mm A");
                        }
                    },
                    { data: 'WORKSHIFT', title: 'Shift' },
                    { data: 'INCHARGE', title: 'In Charge' },
                    
                ], createdRow: function (row, data, index) {
                    if (data.WORKSHIFT == 'DS') {
                        $('td:eq(7)', row).css('background-color', '#E6DB63');  //DAY SHIFT
                    } else {
                        $('td:eq(7)', row).css('background-color', '#2E3033'); //NIGHTSHIFT
                        $('td:eq(7)', row).css('color', '#fff');
                    }
                },
            });
        },
        error: function (err) {
            console.log(err);
        }
    });
}
function UpdateReturnSpout() {
    var RETURNLOTNO = $('#lbl_ReturnLotNo').text();
    var PARTLOTNO = $('#txt_PartLotNo').val();
    var AMOUNT = $('#txt_Amount').val();    
    var CAVITYNO = $('#txt_CavityNo').val();
    var BOXNO = $('#txt_BoxNo').val();

    $.ajax({
        url: "IPS_ReturnSpout.aspx/UpdateIPSReturnSpout",
        type: "POST",
        data: JSON.stringify({
            returnlotno: RETURNLOTNO,
            partlotno: PARTLOTNO,
            amount: AMOUNT,
            cavityno: CAVITYNO,
            boxno: BOXNO
        }),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (e) {
            console.log(e);
            GetIPSReturnSpout();
            $('#ModalEdit').modal('hide');
            updateAlert();
        },
        error: function (errormessage) {
            console.log(errormessage);
        }
    });
}