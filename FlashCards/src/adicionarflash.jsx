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


import { Toaster, toast } from "sonner"

import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"
import { useState } from "react"

export default function AdicionarFlash(props){

    const [nome, setNomeFlash] = useState()
    const [segundos, setSegundosFlash] = useState()
    const [user, setUser] = useState(1)

    async function adicionar(){
        await fetch("https://localhost:7158/addflash", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({
                nome : nome,
                segundos : segundos,
                user: user
            })
        })
        .then(response => response.json())
        .then(data => {
            if(data.id){
                toast.success("Flash adicionado com sucesso!", {
                    duration: 700,
                })
            }
            else{
                toast.error("Erro ao adicionar flash", {
                    duration: 700,
                })
            }
        })

        setNomeFlash("")
        setSegundosFlash("")

        await props.atualizarFlashs()
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
                    <DialogTitle>Adicionar flash</DialogTitle>
                    <DialogDescription>
                        Adicione seu flash aqui. Clique em salvar quando terminar.
                    </DialogDescription>
                    </DialogHeader>
                    <div className="grid gap-4 py-4">
                    <div className="grid grid-cols-4 items-center gap-4">
                        <Label htmlFor="nome" className="text-right">
                        Nome
                        </Label>
                        <Input id="nome" value={nome} className="col-span-3" onChange={(e) => setNomeFlash(e.target.value)}/>
                    </div>
                    <div className="grid grid-cols-4 items-center gap-4">
                        <Label htmlFor="segundos" className="text-right">
                        Segundos
                        </Label>
                        <Input id="segundos" type="number" value={segundos} className="col-span-3" onChange={(e) => setSegundosFlash(e.target.value)}/>
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