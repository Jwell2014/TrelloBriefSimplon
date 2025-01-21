import axios from 'axios';
import { Button } from 'primereact/button';
import { Calendar } from 'primereact/calendar';
import { Dialog } from 'primereact/dialog';
import { Dropdown } from 'primereact/dropdown';
import { InputNumber } from 'primereact/inputnumber';
import { InputText } from 'primereact/inputtext';
import { InputTextarea } from 'primereact/inputtextarea';
import React, { useEffect, useState } from 'react';

interface IAddProjet {
    findNomResponsable: (idResponsable: number | null) => string,
    utilisateur: {
        idutilisateur: number, nom: string; prenom: string; motDePasse: string; description: string; photo: string; poste: string
    }[]
}
function AddProjet({ findNomResponsable, utilisateur }: IAddProjet) {
    const [visible, setVisible] = useState(false);
    const [nomProjet, setNomProjet] = useState('');
    const [idresponsable, setIdresponsable] = useState<number | null>(null);
    const [dateDebut, setDateDebut] = useState<Date | undefined>(undefined);
    const [dateFinPrevue, setDateFinPrevue] = useState<Date | undefined>(undefined);
    const [detailsDuProjet, setDetailsDuProjet] = useState('');

    const responsablesOptions = utilisateur.map(util => ({
        label: `${util.nom} ${util.prenom}`,
        value: util.idutilisateur
    }));

    const testDropdow = () => {
        console.log()
    }

    const createProjet = async () => {
        console.log(nomProjet)
        console.log(idresponsable)
        console.log(dateDebut)
        console.log(dateFinPrevue)
        console.log(detailsDuProjet)

        try {
            const response = await axios.post('https://localhost:7203/api/Projet', {
                "nomProjet": nomProjet,
                "idresponsable": idresponsable,
                "dateDebut": dateDebut,
                "dateFinPrevue": dateFinPrevue,
                "detailsDuProjet": detailsDuProjet
            }, {
                headers: {
                    'Content-Type': 'application/json',
                },
            });

            // La réponse réussie est dans response.data
            console.log(response.data);
            setVisible(false)

        } catch (error) {
            console.error('Erreur lors de la connexion :', error);
        }
    };

    const footerContent = (
        <div>
            <Button label="Annulee" icon="pi pi-times" onClick={() => setVisible(false)} className="p-button-text" />
            <Button label="Creer" icon="pi pi-check" onClick={createProjet} autoFocus />
        </div>
    );

    return (
        <div className="card flex justify-content-center">
            <Button label="Ajouter" icon="pi pi-external-link" onClick={() => setVisible(true)} />
            <Dialog header="Créer un projet" visible={visible} style={{ width: '50vw' }} onHide={() => setVisible(false)} footer={footerContent}>
                <div className="flex flex-wrap justify-content-center align-items-center gap-2">
                    <label className="w-6rem">Nom Projet</label>
                    <InputText
                        id="Nom Projet"
                        type="text"
                        className="w-12rem"
                        value={nomProjet}
                        onChange={(e) => setNomProjet(e.target.value)}
                    />
                </div>
                <div className="flex flex-wrap justify-content-center align-items-center gap-2">
                    <label className="w-6rem">Nom responsable</label>
                    {/* <InputNumber
                        id="Nom Projet"
                        type="number"
                        className="w-12rem"
                        onClick={(e) => console.log(e)}
                    /> */}
                    <Dropdown
                        id="responsableDropdown"
                        optionLabel="label"
                        optionValue="value"
                        value={findNomResponsable(idresponsable)}
                        options={responsablesOptions}
                        onChange={(e) => setIdresponsable(e.value)}
                    />
                </div>
                <div className="flex flex-wrap justify-content-center align-items-center gap-2">
                    <label className="w-6rem">Date debut</label>
                    <Calendar
                        id="dateDebut"
                        className="w-12rem"
                        value={dateDebut}
                        onChange={(e) => setDateDebut(e.value as Date | undefined)}
                    />
                </div>
                <div className="flex flex-wrap justify-content-center align-items-center gap-2">
                    <label className="w-6rem">Date fin</label>
                    <Calendar
                        id="dateFinPrevue"
                        className="w-12rem"
                        value={dateFinPrevue}
                        onChange={(e) => setDateFinPrevue(e.value as Date | undefined)} />
                </div>
                <div className="flex flex-wrap justify-content-center align-items-center gap-2">
                    <label className="w-6rem">description du projet</label>
                    <InputTextarea
                        id="DetailsDuProjet"
                        className="w-12rem"
                        value={detailsDuProjet}
                        onChange={(e) => setDetailsDuProjet(e.target.value)}
                    />
                </div>
            </Dialog>
        </div>
    )
};

export default AddProjet;

