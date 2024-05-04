import React, { useState } from 'react';
import { NavigationBar } from './NavigationBar';

export const Consultation = () => {
  const [nombre, setNombre] = useState("");
  const [citaId, setCitaId] = useState("");
  const [fecha, setFecha] = useState("");
  const [peso, setPeso] = useState(0);
  const [altura, setAltura] = useState(0);
  const [antecedentes, setAntecedentes] = useState("");
  const [diagnostico, setDiagnostico] = useState("");
  const [medicamento, setMedicamento] = useState("");
  const [motivoConsulta, setMotivoConsulta] = useState("");
  const [comentario, setComentario] = useState("");

  const [citas, setCitas] = useState([]);

  const handleSubmit = async (e) => {
    e.preventDefault();

    const data = {
      citaId,
      fecha,
      peso,
      altura,
      antecedentes,
      diagnostico,
      medicamento,
      motivoConsulta,
      comentario
    };
    try {
      const response = await fetch('https://localhost:7089/api/consulta', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
      });

      if (!response.ok) {
        throw new Error('Error al enviar los datos');
      }
      alert('Datos enviados correctamente');
      setCitaId('');
      setFecha('');
      setPeso('');
      setAltura('');
      setAntecedentes('');
      setDiagnostico('');
      setMedicamento('');
      setMotivoConsulta('');
      setComentario('');

    } catch (error) {
      console.error('Error:', error);
      alert('Hubo un error al enviar los datos'); 
    }
    
  }
  return (
    <div >
      <NavigationBar />
      <div className="flex justify-center items-center mt-10 h-screen bg-gray-200">
        <form onSubmit={handleSubmit} className="bg-white p-8 rounded-lg shadow-md max-w-4xl w-full">
          <h2 className="text-2xl font-bold mb-4 text-center">Consulta Médica</h2>
          <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
            <div>
              <label htmlFor="citaId" className="block mb-2">Cita ID:</label>
              <input
                type="text"
                id="citaId"
                value={citaId}
                onChange={(e) => setCitaId(e.target.value)}
                placeholder="Cita ID"
                className="block w-full px-4 py-2 mb-4 border border-blue-200 rounded-md" />
            </div>
            <div>
              <label htmlFor="fecha" className="block mb-2">Fecha:</label>
              <input
                type="date"
                id="fecha"
                value={fecha}
                onChange={(e) => setFecha(e.target.value)}
                placeholder="Fecha"
                className="block w-full px-4 py-2 mb-4 border border-blue-200 rounded-md" />
            </div>
            <div>
              <label htmlFor="peso" className="block mb-2">Peso:</label>
              <input
                type="number"
                id="peso"
                value={peso} onChange={(e) => setPeso(e.target.value)}
                placeholder="Peso"
                className="block w-full px-4 py-2 mb-4 border border-blue-200 rounded-md" />
            </div>
            <div>
              <label htmlFor="altura" className="block mb-2">Altura:</label>
              <input
                type="number"
                id="altura"
                value={altura} onChange={(e) => setAltura(e.target.value)}
                placeholder="Altura"
                className="block w-full px-4 py-2 mb-4 border border-blue-200 rounded-md" />
            </div>
            <div>
              <label htmlFor="antecedentes" className="block mb-2">Antecedentes:</label>
              <textarea
                id="antecedentes"
                value={antecedentes} onChange={(e) => setAntecedentes(e.target.value)}
                placeholder="Antecedentes"
                className="block w-full px-4 py-2 mb-4 border border-blue-200 rounded-md"></textarea>
            </div>
            <div>
              <label htmlFor="diagnostico" className="block mb-2">Diagnóstico:</label>
              <textarea
                id="diagnostico"
                value={diagnostico} onChange={(e) => setDiagnostico(e.target.value)}
                placeholder="Diagnóstico"
                className="block w-full px-4 py-2 mb-4 border border-blue-200 rounded-md"></textarea>
            </div>
            <div>
              <label htmlFor="medicamento" className="block mb-2">Medicamento:</label>
              <textarea
                id="medicamento"
                value={medicamento} onChange={(e) => setMedicamento(e.target.value)}
                placeholder="Medicamento"
                className="block w-full px-4 py-2 mb-4 border border-blue-200 rounded-md"></textarea>
            </div>
            <div>
              <label htmlFor="motivoConsulta" className="block mb-2">Motivo de la consulta:</label>
              <textarea
                id="motivoConsulta"
                value={motivoConsulta} onChange={(e) => setMotivoConsulta(e.target.value)}
                placeholder="Motivo de la consulta"
                className="block w-full px-4 py-2 mb-4 border border-blue-200 rounded-md"></textarea>
            </div>
            <div>
              <label htmlFor="comentario" className="block mb-2">Comentario:</label>
              <textarea
                id="comentario"
                value={comentario} onChange={(e) => setComentario(e.target.value)}
                placeholder="Comentario"
                className="block w-full px-4 py-2 mb-4 border border-blue-200 rounded-md"></textarea>
            </div>
          </div>
          <button type="submit" className="bg-blue-500 text-white px-4 py-2 rounded-md w-full">Enviar Consulta</button>
        </form>
      </div>
    </div>
  );
}
