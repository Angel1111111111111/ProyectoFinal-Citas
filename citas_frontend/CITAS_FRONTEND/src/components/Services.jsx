import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { NavigationBar } from './NavigationBar';
import { constants } from '../helpers/constants';
import DermatologistImage from '../images/dermatologist.jpg';
import NutricionImage from '../images/nutricion.jpg';
import MedicalExamsImage from '../images/medicalexams.jpeg';
import PediatricImage from '../images/pedriatia.jpg';
import PsychologyImage from '../images/psicologia.jpg';

const ServiceItem = ({ serviceName, imageSrc, description, onClick }) => {
  return (
    <div
      onClick={onClick}
      className="bg-white p-4 rounded-lg shadow-md cursor-pointer relative overflow-hidden hover:shadow-lg"
    >
      <div className="flex items-center justify-center rounded-full overflow-hidden mb-2 h-24 w-24">
        <img
          src={imageSrc || DefaultImage}
          alt={serviceName}
          className="w-full h-full object-cover"
        />
      </div>
      <h2 className="text-xl font-semibold">{serviceName}</h2>
      <p className="text-sm">{description}</p>
    </div>
  );
};

export const Services = () => {
  const navigate = useNavigate();
  const [services, setServices] = useState([]);
  const { API_URL } = constants();

  useEffect(() => {
    const fetchServices = async () => {
      try {
        const response = await fetch(`${API_URL}/especialidad`);
        if (!response.ok) {
          throw new Error('Error fetching services');
        }
        const data = await response.json();
        setServices(data);
      } catch (error) {
        console.error('Error fetching services:', error);
      }
    };

    fetchServices();
  }, [API_URL]);

  const handleServiceClick = async (service) => {
    try {
      const response = await fetch(`${API_URL}/doctores/especialidad/${service.id}`);
      if (!response.ok) {
        throw new Error('Error fetching doctors');
      }
      const doctors = await response.json();
      navigate(`/${service.nombre}`, { state: { doctors } });
    } catch (error) {
      console.error('Error fetching doctors:', error);
    }
  };

  return (
    <div>
      <NavigationBar />
      <div className="h-screen bg-gray-300">
        <h1 className="text-3xl font-bold mb-6 text-center p-5 ">Servicios Médicos Disponibles</h1>
        <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-4 px-6">
          {services.map((service) => {
            let imageSrc;
            switch (service.nombre) {
              case 'Dermatologia':
                imageSrc = DermatologistImage;
                break;
              case 'Nutricionistas':
                imageSrc = NutricionImage;
                break;
              case 'Examenes Medicos':
                imageSrc = MedicalExamsImage;
                break;
              case 'Pedriatras':
                imageSrc = PediatricImage;
                break;
              case 'Psicologia':
                imageSrc = PsychologyImage;
                break;
              default:
                imageSrc = PsychologyImage;
                break;
            }

            return (
              <ServiceItem
                key={service.id}
                serviceName={service.nombre}
                imageSrc={imageSrc}
                description={service.descripcion}
                onClick={() => handleServiceClick(service)}
              />
            );
          })}
        </div>
      </div>
    </div>
  );
};
