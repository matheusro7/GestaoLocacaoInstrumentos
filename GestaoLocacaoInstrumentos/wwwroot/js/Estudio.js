document.addEventListener("DOMContentLoaded", function () {
    const estudioTable = document.getElementById("estudioTable");

    if (estudioTable) {
        estudioTable.addEventListener("click", function (event) {
            const target = event.target;

            // Ação para o botão de excluir
            if (target.classList.contains("btn-delete")) {
                const id = target.getAttribute("data-id");
                if (confirm("Tem certeza que deseja excluir este estúdio?")) {
                    fetch(`/Estudio/Delete/${id}`, {
                        method: "POST",
                        headers: {
                            "Content-Type": "application/json",
                            "RequestVerificationToken": document.querySelector('input[name="__RequestVerificationToken"]').value
                        },
                        body: JSON.stringify({ id })
                    })
                        .then(response => {
                            if (response.ok) {
                                alert("Estúdio excluído com sucesso.");
                                location.reload();
                            } else {
                                alert("Erro ao excluir o estúdio.");
                            }
                        })
                        .catch(error => console.error("Erro:", error));
                }
            }
        });
    }

    // Exemplo para validações em formulários
    const formCreateEstudio = document.getElementById("formCreateEstudio");
    if (formCreateEstudio) {
        formCreateEstudio.addEventListener("submit", function (event) {
            const capacidade = document.getElementById("Capacidade").value;
            if (capacidade <= 0) {
                alert("A capacidade deve ser maior que zero.");
                event.preventDefault();
            }
        });
    }
});
