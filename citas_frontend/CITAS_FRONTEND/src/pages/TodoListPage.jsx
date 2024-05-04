import React, { useState, useEffect } from 'react';
import { HistorialCitas, TodoFormCita } from '../components'; 
import { AuthContext } from '../context/AuthContext';

export const TodoListPage = () => {
  const [todoListItems, setTodoListItems] = useState([]);
  const [user, setUser] = useState(JSON.parse(localStorage.getItem('user')) || {});

  const fetchCitas = async () => {
    try {
      const response = await fetch('https://localhost:7125/api/citas', {
        headers: {
          'Content-Type': 'application/json'
        }
      });
      if (!response.ok) {
        throw new Error('Error al obtener la lista de citas.');
      }
      const data = await response.json();
      setTodoListItems(data.data);
    } catch (error) {
      console.error(error);
    }
  };

  useEffect(() => {
    fetchCitas(); 
  }, []);

  const handleCitaAgendada = async (nuevaCita) => {
    try {
      const response = await fetch('https://localhost:7125/api/citas', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(nuevaCita)
      });
      if (!response.ok) {
        throw new Error('Error al agregar la nueva cita.');
      }
      const data = await response.json();
      setTodoListItems(prevCitas => [...prevCitas, data.data]);
    } catch (error) {
      console.error(error);
    }
  };

  const handleEditarCita = async (citaEditada) => {
    try {
      const response = await fetch(`https://localhost:7125/api/citas/${citaEditada.id}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(citaEditada)
      });
      if (!response.ok) {
        throw new Error('Error al editar la cita.');
      }
      const data = await response.json();
      setTodoListItems(prevCitas =>
        prevCitas.map(cita =>
          cita.id === data.data.id ? { ...cita, ...data.data } : cita
        )
      );
    } catch (error) {
      console.error(error);
    }
  };

  const handleEliminarCita = async (idCita) => {
    try {
      const response = await fetch(`https://localhost:7125/api/citas/${idCita}`, {
        method: 'DELETE',
        headers: {
          'Authorization' : `Bearer ${user.token}`,
          'Content-Type': 'application/json'
        }
      });
      if (!response.ok) {
        throw new Error('Error al eliminar la cita.');
      }
      setTodoListItems(prevCitas =>
        prevCitas.filter(cita => cita.id !== idCita)
      );
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <>
      <div className="mx-10 bg-white shadow-lg overflow-hidden">
        <div className="px-4 py-2">
          <h1 className="text-gray-800 font-bold text-2xl uppercase">
            Lista de Citas
          </h1>
          <TodoFormCita 
            onCitaAgendada={handleCitaAgendada}
            onEditarCita={handleEditarCita} 
          />
          
          {/* <HistorialCitas 
            todoListItems={todoListItems} // Pasar la lista de citas como prop
            // Otras props necesarias para la lista de citas
            onEditarCita={handleEditarCita} // Proporcionar la función de devolución de llamada para manejar la edición de una cita
            onEliminarCita={handleEliminarCita} // Proporcionar la función de devolución de llamada para manejar la eliminación de una cita
          /> */}
        </div>
      </div>
    </>
  );
};
