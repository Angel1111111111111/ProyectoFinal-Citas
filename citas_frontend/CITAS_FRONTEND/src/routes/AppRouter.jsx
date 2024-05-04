import { Route, Routes } from "react-router-dom"
import { LoginPage, Register } from "../pages"
import { PublicRoute } from "./PublicRoute"
import { PrivateRoute } from "./PrivateRoute"
import {
    Consultation,
    EventSaves,
    HistorialCitas,
    HistorialMedico,
    Services,
    TodoFormCita
} from "../components"
import { Dermatologist } from "../medicalServices/Dermatologist"
import { MedicalExams } from "../medicalServices"
import { Nutrition } from "../medicalServices/Nutrition"
import { Pediatrics } from "../medicalServices/Pediatrics"
import { Psychology } from "../medicalServices/Psychology"

export const AppRouter = () => {
    return (
        <>
            <Routes>
                <Route
                    path='/login' element={
                        <PublicRoute>
                            <LoginPage />
                        </PublicRoute>
                        //     <PublicRoute>
                        //     <ResetPasswordPage />
                        // </PublicRoute>
                    }
                />
                <Route
                    path='/' element={
                        <PrivateRoute>
                            <Services />
                        </PrivateRoute>
                    }
                />
                <Route
                    path='/todoForm'
                    element={
                        <PrivateRoute>
                            <TodoFormCita />
                        </PrivateRoute>
                    }
                />
                <Route
                    path='/register'
                    element={
                        <PublicRoute>
                            <Register />
                        </PublicRoute>
                    }
                />
                <Route
                    path='/historialMedico'
                    element={
                        <PrivateRoute>
                            <HistorialMedico />
                        </PrivateRoute>
                    }
                />
                <Route
                    path='/historialCita'
                    element={
                        <PrivateRoute>
                            <HistorialCitas />
                        </PrivateRoute>
                    }
                />
                <Route
                    path='/Dermatologia'
                    element={
                        <PrivateRoute>
                            <Dermatologist />
                        </PrivateRoute>
                    }
                />
                <Route
                    path='/Examenes Medicos'
                    element={
                        <PrivateRoute>
                            <MedicalExams />
                        </PrivateRoute>
                    }
                />
                <Route
                    path='/consultation'
                    element={
                        <PrivateRoute>
                            <Consultation />
                        </PrivateRoute>
                    }
                />
                <Route
                    path='/Nutricionistas'
                    element={
                        <PrivateRoute>
                            <Nutrition />
                        </PrivateRoute>
                    }
                />
                <Route
                    path='/Pedriatras'
                    element={
                        <PrivateRoute>
                            <Pediatrics />
                        </PrivateRoute>
                    }
                />
                <Route
                    path='/Psicologia'
                    element={
                        <PrivateRoute>
                            <Psychology />
                        </PrivateRoute>
                    }
                />
                <Route
                    path='/historialMedico'
                    element={
                        <PrivateRoute>
                            <HistorialMedico />
                        </PrivateRoute>
                    }
                />

                <Route
                    path='/eventos'
                    element={
                        <PrivateRoute>
                            <EventSaves />
                        </PrivateRoute>
                    }
                />
            </Routes>
        </>
    )
}
