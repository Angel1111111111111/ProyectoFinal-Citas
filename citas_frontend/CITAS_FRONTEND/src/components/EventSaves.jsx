import React, { useState, useEffect } from 'react';
import { NavigationBar } from './NavigationBar';

export const EventSaves = () => {
    const [logs, setLogs] = useState([]);

    useEffect(() => {
        const fetchLogs = async () => {
            try {
                const response = await fetch('https://localhost:7089/api/log');
                if (!response.ok) {
                    throw new Error('Error al obtener los registros de logs');
                }
                const data = await response.json();
                setLogs(data.data);
            } catch (error) {
                console.error('Error:', error);
            }
        };

        fetchLogs();
    }, []);

    return (
        <div>
            <NavigationBar />
            <div className="container mx-auto px-4 py-8">
                <h1 className="text-3xl font-bold mb-4">Registros de Logs</h1>
                <div className="overflow-x-auto">
                    <table className="table-auto w-full border-collapse border border-gray-400">
                        <thead>
                            <tr className="bg-gray-200">
                                <th className="px-4 py-2 text-left">Usuario</th>
                                <th className="px-4 py-2 text-left">Fecha y Hora</th>
                                <th className="px-4 py-2 text-left">Acción</th>
                            </tr>
                        </thead>
                        <tbody>
                            {logs.map((log, index) => (
                                <tr key={index} className={index % 2 === 0 ? "bg-gray-100" : "bg-white"}>
                                    <td className="px-4 py-2">{log.usuario}</td>
                                    <td className="px-4 py-2">{log.fecha}</td>
                                    <td className="px-4 py-2">{log.accion}</td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    );
};
