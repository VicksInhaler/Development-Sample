$(document).ready(function (e) {

    GetUserData();
    $('[id*=btnUpdate]').hide();
    $('[id*=txtID]').attr('disabled', true);
    $('[id*=txtID]').hide();

    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
    function EndRequestHandler(sender, args) {
        GetUserData();
        $('[id*=btnUpdate]').hide();
        $('[id*=txtID]').attr('disabled', true);
        $('[id*=txtID]').hide();
    }
});
var MainTable = $('.useraccounts').DataTable({
    columnDefs: [
        { 'visible': false, 'targets': [0] }
    ],
    columns: [
        { data: 'ID', title: 'ID' },
        { data: 'EMPLOYEENO', title: 'EMPLOYEENO' },
        { data: 'PASSWORD', title: 'PASSWORD' },
        { data: 'FIRSTNAME', title: 'FIRSTNAME' },
        { data: 'MIDDLENAME', title: 'MIDDLENAME' },
        { data: 'LASTNAME', title: 'LASTNAME' },
        { data: 'NICKNAME', title: 'NICKNAME' },
        { data: 'POSITION', title: 'POSITION' },
        { data: 'SECTION', title: 'SECTION' },
        { data: 'ROLE', title: 'ROLE' },
        {
            data: 'UPDATEDDATE', title: 'Date Time',
            render: function (d) {
                return moment(d).format("MM/DD/YYYY hh:mm:ss A");
            }
        },
        { data: 'UPDATEDBY', title: 'In Charge' },
        { data: 'WORKSHIFT', title: 'Work Shift' },
        {
            data: null,
            title: 'Action',
            className: "dt-center editor-edit",
            defaultContent: '<button type="button" class="btn-xs btn-info"><i class="fas fa-pencil-alt"></i></button>',
            orderable: false
        }
    ],
    searching: true,
    paging: true,
    info: true,
    ordering: false,
    scrollX: true
});
$('.useraccounts').DataTable();

function GetUserData() {
    $.ajax({
        type: "POST",
        url: "UserAccounts.aspx/GetUserData",
        data: "{}",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (e) {
            var d = JSON.parse(e.d);
            //console.log(d);
            $('.useraccounts').DataTable().clear().destroy();
            if ($.fn.dataTable.isDataTable('.useraccounts')) {
                $('.useraccounts').DataTable().clear();
                $('.useraccounts').DataTable().destroy();
                $('.useraccounts').empty();
                $('.useraccounts').addClass("table  table-bordered table-hover");
                $('.useraccounts').css("width", "100%")
            }
            MainTable = $('.useraccounts').DataTable({

                data: d,
                columnDefs: [
                    { 'visible': false, 'targets': [0] }
                ],
                columns: [
                    { data: 'ID', title: 'ID' },
                    { data: 'EMPLOYEENO', title: 'EMPLOYEENO' },
                    { data: 'PASSWORD', title: 'PASSWORD' },
                    { data: 'FIRSTNAME', title: 'FIRSTNAME' },
                    { data: 'MIDDLENAME', title: 'MIDDLENAME' },
                    { data: 'LASTNAME', title: 'LASTNAME' },
                    { data: 'NICKNAME', title: 'NICKNAME' },
                    { data: 'POSITION', title: 'POSITION' },
                    { data: 'SECTION', title: 'SECTION' },
                    { data: 'ROLE', title: 'ROLE' },
                    {
                        data: 'UPDATEDDATE', title: 'Date Time',
                        render: function (d) {
                            return moment(d).format("MM/DD/YYYY hh:mm:ss A");
                        }
                    },
                    { data: 'UPDATEDBY', title: 'In Charge' },
                    { data: 'WORKSHIFT', title: 'Work Shift' },
                    {
                        data: null,
                        title: 'Action',
                        className: "dt-center editor-edit",
                        defaultContent: '<button type="button" class="btn-xs btn-info"><i class="fas fa-pencil-alt"></i></button>',
                        orderable: false
                    },
                ],
                createdRow: function (row, data, index) {

                    if (data.WORKSHIFT == 'DS') {
                        $('td:eq(11)', row).css('background-color', '#E6DB63');  //DAY SHIFT
                    } else {
                        $('td:eq(11)', row).css('background-color', '#2E3033');//NIGHTSHIFT
                        $('td:eq(11)', row).css('color', '#fff');
                    }
                    if (data.SECTION == 'IBPP') {
                        $('td:eq(7)', row).css('background-color', '#E6DB63');  //DAY SHIFT
                    } else {
                        $('td:eq(7)', row).css('background-color', '#2E3033');//NIGHTSHIFT
                        $('td:eq(7)', row).css('color', '#fff');
                    }
                },
                searching: true,
                paging: true,
                info: true,
                ordering: false,
                scrollX: true
            });
            $('.useraccounts').on('click', 'td.editor-edit', function (e) {
                $('[id*=btnUpdate]').show();
                var table = $('.useraccounts').DataTable();
                var data = MainTable.row($(this).closest('tr')).data();
                var id = data[Object.keys(data)[0]];
                var empno = data[Object.keys(data)[1]];
                var fname = data[Object.keys(data)[3]];
                var mname = data[Object.keys(data)[4]];
                var lname = data[Object.keys(data)[5]];
                var nname = data[Object.keys(data)[6]];
                var position = data[Object.keys(data)[7]];
                var section = data[Object.keys(data)[8]];               
                var role = data[Object.keys(data)[9]];               
                var workshift = data[Object.keys(data)[10]];               
                   $('[id*=btnSave]').hide();
                   $('[id*=btnUpdate]').show();
                    $('[id*=txtID]').val(id);
                    $('[id*=txtEmployeeNo]').val(empno);
                    $('[id*=txtFirstName]').val(fname);
                    $('[id*=txtMiddleName]').val(mname);
                    $('[id*=txtLastName]').val(lname);
                    $('[id*=txtNickName]').val(nname);
                    $('[id*=ddlPosition]').val(position).trigger('change');
                    $('[id*=ddlSection]').val(section).trigger('change');
                    $('[id*=ddlRole]').val(role).trigger('change');
                    $('[id*=ddlWorkShift]').val(workshift).trigger('change');
            })
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
