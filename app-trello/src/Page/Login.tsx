import React, { useState } from 'react';
import { Divider } from 'primereact/divider';
import { InputText } from 'primereact/inputtext';
import { Button } from 'primereact/button';
import axios from 'axios';
import CardProjet from '../Component/CardProjet';
import Profile from './Profile';
import SignUp from './SignUp';

interface ILoginProps {
    connected: boolean
    setConnected: React.Dispatch<React.SetStateAction<boolean>>
}
function Login({ connected, setConnected }: ILoginProps) {

    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');

    const handleLogin = async () => {
        console.log(username)
        console.log(password)

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

        } catch (error) {
            console.error('Erreur lors de la connexion :', error);
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