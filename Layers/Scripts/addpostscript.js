// Get the modal
var modal = document.getElementById("myModal");

// Get the button that opens the modal
// var btn = document.getElementByClassName("post-adding");

// Get the <span> element that closes the modal

var header = document.getElementsByTagName("header")[0];

var addNote = document.getElementById("addNote");

// When the user clicks on the button, open the modal
var span = document.getElementsByClassName("close")[0];


addNote.onclick = function (event) {
        modal.style.display = "block";
        content.style.opacity = 0.6;
        header.style.opacity = 0.6;
    }

// When the user clicks on <span> (x), close the modal
span.onclick = function (event) {
    modal.style.display = "none";
    content.style.opacity = 1;
    header.style.opacity = 1;
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
  if (event.target == modal) {
  modal.style.display = "none";
  content.style.opacity = 1;
  header.style.opacity = 1;  }
}

console.log("sdsdsd");
$('#modal-form').submit(function (e) {
    e.preventDefault();
    console.log("asd");
     /*   $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {
                if (result.success) {
                    $('#myModal').modal('hide');
                    $('#progress').hide();
                    $("#show_user_info").load('/User/ShowUserRecords');
                } else {
                    $('#progress').hide();
                    $('#myModalContent').html(result);
                    bindForm();
                }
            }
        });*/
        return false;
    });