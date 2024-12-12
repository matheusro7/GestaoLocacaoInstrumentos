document.addEventListener("DOMContentLoaded", function () {
    const deleteButtons = document.querySelectorAll(".btn-danger");

    deleteButtons.forEach(button => {
        button.addEventListener("click", function (event) {
            if (!confirm("Tem certeza que deseja excluir este funcionário?")) {
                event.preventDefault();
            }
        });
    });
});
