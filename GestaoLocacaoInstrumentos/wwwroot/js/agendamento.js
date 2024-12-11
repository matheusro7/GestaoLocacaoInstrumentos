document.addEventListener("DOMContentLoaded", function () {
    const agendamentoTable = document.getElementById("agendamentoTable");

    if (agendamentoTable) {
        agendamentoTable.addEventListener("click", function (event) {
            const target = event.target;

            // Ação para o botão de excluir
            if (target.classList.contains("btn-delete")) {
                const id = target.getAttribute("data-id");
                if (confirm("Tem certeza que deseja excluir este agendamento?")) {
                    fetch(`/Agendamento/Delete/${id}`, {
                        method: "POST",
                        headers: {
                            "Content-Type": "application/json",
                            "RequestVerificationToken": document.querySelector('input[name="__RequestVerificationToken"]').value
                        },
                        body: JSON.stringify({ id })
                    })
                        .then(response => {
                            if (response.ok) {
                                alert("Agendamento excluído com sucesso.");
                                location.reload();
                            } else {
                                alert("Erro ao excluir o agendamento.");
                            }
                        })
                        .catch(error => console.error("Erro:", error));
                }
            }
        });
    }

    // Exemplo para validações em formulários
    const formCreateAgendamento = document.getElementById("formCreateAgendamento");
    if (formCreateAgendamento) {
        formCreateAgendamento.addEventListener("submit", function (event) {
            const data = document.getElementById("Data").value;
            const horario = document.getElementById("Horario").value;

            if (!data || !horario) {
                alert("Todos os campos são obrigatórios.");
                event.preventDefault();
            }
        });
    }
});
