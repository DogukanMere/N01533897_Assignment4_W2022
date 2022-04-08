
window.onload = function () {

    //DOM for form elements
    var teacherFname = document.querySelector(".tFname");
    var teacherLname = document.querySelector(".tLname");
    var employeeNumber = document.querySelector(".empNum");
    var hireDate = document.querySelector(".hireDate");
    var salary = document.querySelector(".salary");
    var teacherbutton = document.getElementById("teacherbutton");
    let errorMessage = document.querySelector(".errorMessage");
    let errorMessage2 = document.querySelector(".errorMessage2");
    let errorMessage3 = document.querySelector(".errorMessage3");
    let errorMessage4 = document.querySelector(".errorMessage4");
    let errorMessage5 = document.querySelector(".errorMessage5");

    //When the submit button clicked
    teacherbutton.onclick = processForm;

    //Do form validation
    function processForm() {
        //Check whether or not each input is filled
        if (teacherFname.value === '') {
            errorMessage.style.visibility = 'unset';
            teacherFname.focus();
            return false;
        } else {
            errorMessage.style.visibility = 'hidden';
        }

        if (teacherLname.value === '') {
            errorMessage2.style.visibility = 'unset';
            teacherLname.focus();
            return false;
        } else {
            errorMessage2.style.visibility = 'hidden';
        }

        if (employeeNumber.value === '') {
            errorMessage3.style.visibility = 'unset';
            employeeNumber.focus();
            return false;
        } else {
            errorMessage3.style.visibility = 'hidden';
        }

        if (hireDate.value === '') {
            errorMessage4.style.visibility = 'unset';
            hireDate.focus();
            return false;
        } else {
            errorMessage4.style.visibility = 'hidden';
        }

        if (salary.value === '') {
            errorMessage5.style.visibility = 'unset';
            salary.focus();
            return false;
        } else {
            errorMessage5.style.visibility = 'hidden';
        }

        //If all fields filled return true
        return true;
    }
    return false;
}