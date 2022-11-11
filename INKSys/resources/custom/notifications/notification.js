

function saveAlert() {
    Swal.fire({
        position: 'top',
        title: 'Your work has been saved!',
        text: 'You can now view the data in the table below.',
        icon: 'success',
        showConfirmButton: false,
        timer: 1300,
        showClass: {
            popup: 'animate__animated animate__fadeInDown'
        },
        hideClass: {
            popup: 'animate__animated animate__fadeOutUp'
        }
    })
}

function emptyFieldsAlert() {
    Swal.fire({
        position: 'top',
        title: 'Fill All Mandatory Fields!',
        text: 'Dont leave the textfields empty',
        icon: 'warning',
        showConfirmButton: false,
        timer: 1300,
        showClass: {
            popup: 'animate__animated animate__fadeInDown'
        },
        hideClass: {
            popup: 'animate__animated animate__fadeOutUp'
        }
    })
}

function updateAlert() {
    Swal.fire({
        position: 'top',
        title: 'Your work has been updated!',
        text: 'You can now view the data in the table below.',
        icon: 'info',
        showConfirmButton: true,
        timer: 4000,
        showClass: {
            popup: 'animate__animated animate__fadeInDown'
        },
        hideClass: {
            popup: 'animate__animated animate__fadeOutUp'
        }
    })
}

function dataFoundAlert() {
    Swal.fire({
        position: 'top',
        title: 'Data Found!',
        text: 'Awesome',
        icon: 'success',
        showConfirmButton: false,
        timer: 1300,
        showClass: {
            popup: 'animate__animated animate__fadeInDown'
        },
        hideClass: {
            popup: 'animate__animated animate__fadeOutUp'
        }
    })
}

function noDataFoundAlert() {
    Swal.fire({
        position: 'top',
        title: 'No Data Found!',
        text: 'Input Valid Data and Try Again!',
        icon: 'error',
        showConfirmButton: false,
        timer: 1300,
        showClass: {
            popup: 'animate__animated animate__fadeInDown'
        },
        hideClass: {
            popup: 'animate__animated animate__fadeOutUp'
        }
    })
}

function emptyFields() {
    Swal.fire({
        position: 'top',
        title: 'OOPS! Empty Fields',
        text: 'Fill All Mandatory Fields',
        icon: 'error',
        showConfirmButton: false,
        timer: 1300,
        showClass: {
            popup: 'animate__animated animate__fadeInDown'
        },
        hideClass: {
            popup: 'animate__animated animate__fadeOutUp'
        }
    })
}
function ModelCodeMissingAlert() {
    Swal.fire({
        position: 'top',
        title: 'OOPS!!! Must input Model Partcode First!',
        text: 'Enter Model Partcode!',
        icon: 'warning',
        // showConfirmButton: false,
        //timer: 2000,
        showClass: {
            popup: 'animate__animated animate__fadeInDown'
        },
        hideClass: {
            popup: 'animate__animated animate__fadeOutUp'
        }
    })
}

function changeModelAlert() {
    Swal.fire({
        title: 'Are you sure to Change The Model?',
        showDenyButton: true,
        /*showCancelButton: true,*/
        confirmButtonText: 'OK',
        denyButtonText: 'CANCEL',
    }).then((result) => {
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed) {
            Swal.fire('Success', 'Model has been Change!', 'success')
        } 
    })
}
function ChangeModelAlert() {
    Swal.fire({
        position: 'top',
        title: 'Model Change Successfully',
        text: 'You can now insert new model!',
        icon: 'success',
        // showConfirmButton: false,
        //timer: 2000,
        showClass: {
            popup: 'animate__animated animate__fadeInDown'
        },
        hideClass: {
            popup: 'animate__animated animate__fadeOutUp'
        }
    })
}

