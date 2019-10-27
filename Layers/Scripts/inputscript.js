$(document).ready(function(){

$(".register-button").attr("disabled", true);
	$("#confirm-password").addClass("errorLine");


    var passwordPattern = /^((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,20})$/;

var pass;
var cpass;

$("#confirm-password").on('change keyup paste', function(){

if(($("#confirm-password").val()) != $("#password").val())
{
    $(".register-button").attr("disabled", true);
	$("#confirm-password").addClass("errorLine");
}
else 

{
	cpass = $("#confirm-password").val();
	$("#confirm-password").removeClass();
    $(".register-button").removeAttr("disabled");
    
}

});

    $("#password").on('change keyup paste', function () {

        if (!(passwordPattern.test($("#password").val()))) {
            $(".register-button").attr("disabled", true);
            $("#password").addClass("errorLine");
        }
        else {
            $("#password").removeClass();
            $(".register-button").attr("disabled", false);

        }

    });

});