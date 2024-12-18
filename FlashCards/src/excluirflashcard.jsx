import {
    AlertDialog,
    AlertDialogAction,
    AlertDialogCancel,
    AlertDialogContent,
    AlertDialogDescription,
    AlertDialogFooter,
    AlertDialogHeader,
    AlertDialogTitle,
    AlertDialogTrigger,
} from "@/components/ui/alert-dialog"

import { Button } from "@/components/ui/button"
import { useState } from "react"

export default function ExcluirFlashCard(props){

    const [idExcluir, setIdExcluir] = useState(props.excluir.id)

    async function excluir(){
        await fetch(`https://localhost:7158/deleteteste/${idExcluir}`, {
            method : "DELETE",
            headers: {
                'Content-Type': 'application/json',
            }
        })

        await props.atualizarFlashCards()
    }

    return(
        <>
            <AlertDialog>
                <AlertDialogTrigger>
                    <Button className="mt-6">Excluir</Button>
                </AlertDialogTrigger>
                <AlertDialogContent>
                    <AlertDialogHeader>
                    <AlertDialogTitle>Excluir flashCard</AlertDialogTitle>
                    <AlertDialogDescription>
                        Esta ação não pode ser desfeita. Isso excluirá permanentemente seu flashcard.
                    </AlertDialogDescription>
                    </AlertDialogHeader>
                    <AlertDialogFooter>
                    <AlertDialogCancel>Cancelar</AlertDialogCancel>
                    <AlertDialogAction onClick={excluir}>Confirmar</AlertDialogAction>
                    </AlertDialogFooter>
                </AlertDialogContent>
            </AlertDialog>
        </>
    )
}