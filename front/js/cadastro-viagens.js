async function handleSubmitForm(event) {
  event.preventDefault();

  const destino = document.getElementById('destino').value;
  const dataPartida = document.getElementById('DataPartida').value;
  const dataRetorno = document.getElementById('DataRetorno').value;
  const nomeViajante = document.getElementById('NomeViajante').value;
  const preco = document.getElementById('Preco').value;
  const viagemEditandoId = document.getElementById('viagemEditandoId').value;

  const viagem = {
    id: viagemEditandoId || undefined, // Se estiver editando, usa o ID existente
    destino,
    dataPartida,
    dataRetorno,
    nomeViajante,
    preco: Number(preco)
  };

  try {
    let response;
    if (viagemEditandoId) {
      // Edição
      response = await fetch(`http://localhost:5199/api/viagens/${viagemEditandoId}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(viagem)
      });
    } else {
      // Cadastro
      response = await fetch('http://localhost:5199/api/viagens', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(viagem)
      });
    }

    if (!response.ok) {
      alert('Erro ao salvar viagem!');
      return;
    }

    // Limpa o formulário e reseta o modo edição
    event.target.reset();
    document.querySelector('.form-viagem button[type="submit"]').textContent = 'Salvar';

    if (typeof renderViagens === 'function') {
      renderViagens();
    }
  } catch (error) {
    alert('Erro ao salvar viagem!');
  }
}

document.addEventListener('DOMContentLoaded', () => {
  const form = document.querySelector('.form-viagem');
  if (form) {
    form.addEventListener('submit', handleSubmitForm);
  }
});