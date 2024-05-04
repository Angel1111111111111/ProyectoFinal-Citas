import React, { useState, useEffect } from 'react';

export const EventoLogs = () => {
  const [logs, setLogs] = useState([]);

  useEffect(() => {
    const fetchLogs = async () => {
      try {
        const response = await fetch('https://localhost:7089/api/log', {
          method: 'GET',
          headers: {
            'Content-Type': 'application/json'
          }
        });

        if (!response.ok) {
          throw new Error('Error al traer los datos');
        }

        const data = await response.json();
        setLogs(data);
      } catch (error) {
        console.error('Error al obtener los registros de logs:', error);
      }
    };

    fetchLogs();
  }, []);

  return (
    <div>
      <h1>Registros de Logs</h1>
      <table>
        <thead>
          <tr>
            <th>Fecha y Hora</th>
            <th>Usuario</th>
            <th>Acción</th>
            <th>Detalle</th>
          </tr>
        </thead>
        <tbody>
          {logs.map(log => (
            <tr key={log.id}>
              <td>{log.fecha}</td>
              <td>{log.user.nombre}</td>
              <td>{log.accion}</td>
              <td>{log.detalle}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};
