document.addEventListener("DOMContentLoaded", function () {
    const deleteButtons = document.querySelectorAll(".btn-danger");

    deleteButtons.forEach(button => {
        button.addEventListener("click", function (event) {
            if (!confirm("Tem certeza que deseja excluir este funcionário?")) {
                event.preventDefault();


//document.addEventListener("DOMContentLoaded", function () {
//     const editButtons = document.querySelectorAll(".btn-warning");
//
//      editButtons.forEach(button => {
//         button.addEventListener("click", function (event) {
//            if (!confirm("Deseja realmente editar este funcionário?")) {
//                 event.preventDefault();
             }
         });
     });
});
