import { Button } from "@/components/ui/button"
import {
    Dialog,
    DialogContent,
    DialogDescription,
    DialogFooter,
    DialogHeader,
    DialogTitle,
    DialogTrigger,
} from "@/components/ui/dialog"

import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"

import { Toaster, toast } from "sonner";

import { useState } from "react"

export default function AdicionarCard(props){

    const [perguntaCard, setPerguntaCard] = useState()
    const [respostaCard, setRespostaCard] = useState()

    async function adicionar(){
        await fetch("https://localhost:7158/addcard", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({
                pergunta: perguntaCard,
                resposta: respostaCard,
            })
        })
        .then(response => response.json())
        .then(data => {
            if(data.id){
                toast.success("Card adicionado com sucesso!")
            }
            else{
                toast.error("Erro ao adicionar card")
            }
        })

        setPerguntaCard("")
        setRespostaCard("")

        await props.atualizarCards()
    }

    return(
        <>
            <Toaster/>
            <Dialog>
            <div class="w-32">
                <DialogTrigger asChild>
                    <Button>Adicionar</Button>
                </DialogTrigger>
            </div>
                <DialogContent className="sm:max-w-[425px]">
                    <DialogHeader>
                    <DialogTitle>Adicionar card</DialogTitle>
                    <DialogDescription>
                        Adicione seu card aqui. Clique em salvar quando terminar.
                    </DialogDescription>
                    </DialogHeader>
                    <div className="grid gap-4 py-4">
                    <div className="grid grid-cols-4 items-center gap-4">
                        <Label htmlFor="pergunta" className="text-right">
                        Pergunta
                        </Label>
                        <Input id="pergunta" value={perguntaCard} className="col-span-3" onChange={(e) => setPerguntaCard(e.target.value)}/>
                    </div>
                    <div className="grid grid-cols-4 items-center gap-4">
                        <Label htmlFor="resposta" className="text-right">
                        Resposta
                        </Label>
                        <Input id="resposta" value={respostaCard} className="col-span-3" onChange={(e) => setRespostaCard(e.target.value)}/>
                    </div>
                    </div>
                    <DialogFooter>
                    <Button onClick={adicionar}>Adicionar</Button>
                    </DialogFooter>
                </DialogContent>
                </Dialog>
        </>
    )
}