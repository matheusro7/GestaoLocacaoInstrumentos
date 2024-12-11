document.addEventListener("DOMContentLoaded", function () {
    const instrumentoTable = document.getElementById("instrumentoTable");

    if (instrumentoTable) {
        instrumentoTable.addEventListener("click", function (event) {
            const target = event.target;

            // Ação para o botão de excluir
            if (target.classList.contains("btn-delete")) {
                const id = target.getAttribute("data-id");
                if (confirm("Tem certeza que deseja excluir este instrumento?")) {
                    fetch(`/Instrumento/Delete/${id}`, {
                        method: "POST",
                        headers: {
                            "Content-Type": "application/json",
                            "RequestVerificationToken": document.querySelector('input[name="__RequestVerificationToken"]').value
                        },
                        body: JSON.stringify({ id })
                    })
                        .then(response => {
                            if (response.ok) {
                                alert("Instrumento excluído com sucesso.");
                                location.reload();
                            } else {
                                alert("Erro ao excluir o instrumento.");
                            }
                        })
                        .catch(error => console.error("Erro:", error));
                }
            }
        });
    }

    // Exemplo para interações com formulários
    const formCreateInstrumento = document.getElementById("formCreateInstrumento");
    if (formCreateInstrumento) {
        formCreateInstrumento.addEventListener("submit", function (event) {
            const valorAluguel = document.getElementById("ValorAluguel").value;
            if (valorAluguel <= 0) {
                alert("O valor do aluguel deve ser maior que zero.");
                event.preventDefault();
            }
        });
    }
});
