export async function apagarViagem(id) {
  if (!confirm('Tem certeza que deseja apagar esta viagem?')) return;

  try {
    const response = await fetch(`http://localhost:5199/api/viagens/${id}`, {
      method: 'DELETE'
    });
    if (!response.ok) {
      alert('Erro ao apagar viagem!');
      return;
    }
    // Atualiza a lista de viagens
    if (typeof renderViagens === 'function') renderViagens();
  } catch (error) {
    alert('Erro ao apagar viagem!');
  }
}