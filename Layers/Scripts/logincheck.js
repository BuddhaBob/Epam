$(document).ready(function(){

$(".register-button").attr("disabled", true);
	$("#password").addClass("errorLine");


var passwordPattern = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z]{8,}$/;

var pass;
var cpass;

$("#password").on('change keyup paste', function(){

    if (passwordPattern.test($("#password").val()))
{
	$(".register-button").attr("disabled", true);
	$("#мpassword").addClass("errorLine");
}
else 
{
	cpass = $("#password").val();
	$("#password").removeClass();
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