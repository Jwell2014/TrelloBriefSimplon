import React, { useState } from 'react';
import { Divider } from 'primereact/divider';
import { InputText } from 'primereact/inputtext';
import { Button } from 'primereact/button';
import axios from 'axios';
import CardProjet from '../Component/CardProjet';
import Profile from './Profile';
import SignUp from './SignUp';
import { Dialog } from 'primereact/dialog';

interface ILoginProps {
    connected: boolean
    setConnected: React.Dispatch<React.SetStateAction<boolean>>
}
function Login({ connected, setConnected }: ILoginProps) {

    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [visible, setVisible] = useState<boolean>(false);
    const [message, setMessage] = useState<string>("");


    const handleLogin = async () => {

        try {
            const response = await axios.post('https://localhost:7203/api/Home', {
                "nom": username,
                "motDePasse": password,
            }, {
                headers: {
                    'Content-Type': 'application/json',
                },
            });

            // La réponse réussie est dans response.data
            console.log(response.data);
            setConnected(response.data)
            if (response.data === false) {
                setVisible(true);
                setMessage("Votre nom d'utilisateur ou votre mot de passe est incorrect.");
            }
            if (!username) {
                setVisible(true);
                setMessage("Le nom d'utilisateur est requis.");
            }
            if (!password) {
                setVisible(true);
                setMessage("Le mot de passe est requis.");
            }

        } catch (error: any) {
            if (error.response) {
                // Erreurs de réponse (backend)
                console.log('Erreur de la réponse :', error.response.data);
                console.log('Status code :', error.response.status);
            } else if (error.request) {
                // La requête a été envoyée mais aucune réponse n'a été reçue
                console.log('Erreur de la requête :', error.request);
            } else {
                // Autre erreur
                console.log('Erreur inconnue :', error.message);
            }

        }
    };

    return (
        <div>
            <div className="flex flex-column m-auto h-screen md:flex-row">
                <div className="w-full md:w-5 flex flex-column align-items-center justify-content-center gap-3 py-5">
                    <div className="flex flex-wrap justify-content-center align-items-center gap-2">
                        <label className="w-6rem">Username</label>
                        <InputText
                            id="Nom"
                            type="text"
                            className="w-12rem"
                            value={username}
                            onChange={(e) => setUsername(e.target.value)}
                        />
                    </div>
                    <div className="flex flex-wrap justify-content-center align-items-center gap-2">
                        <label className="w-6rem">Password</label>
                        <InputText
                            id="Mot de passe"
                            type="password"
                            className="w-12rem"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                        />
                    </div>
                    <Button label="Connecter" icon="pi pi-user" className="w-10rem mx-auto" onClick={handleLogin}></Button>
                </div>
                <Dialog header="Erreur" visible={visible} position="left" style={{ width: '50vw' }} onHide={() => { if (!visible) return; setVisible(false); }} draggable={false} resizable={false}>
                    <p>{message}</p>
                </Dialog>
                <div className="w-full md:w-2">
                    <Divider layout="vertical" className="hidden md:flex">
                        <b>OR</b>
                    </Divider>
                    <Divider layout="horizontal" className="flex md:hidden" align="center">
                        <b>OR</b>
                    </Divider>
                </div>
                <div className="w-full md:w-5 flex align-items-center justify-content-center">
                    <SignUp setConnected={setConnected} />
                </div>
            </div>
        </div>
    );
};

export default Login;