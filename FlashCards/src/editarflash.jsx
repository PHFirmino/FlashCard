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

import { Toaster, toast } from "sonner"

import { useState } from "react"

export default function EditarFlash(props){

    const [idflash, setIdFlash] = useState(props.editar.id)
    const [nome, setNomeFlash] = useState(props.editar.nome)
    const [segundos, setSegundosFlash] = useState(props.editar.segundos)
    const [user, setUser] = useState(1)

    async function editar(){
        await fetch(`https://localhost:7158/editflash/${idflash}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body : JSON.stringify({                
                nome: nome,
                segundos: segundos,
                user: user
            })
        })
        .then(response => response.json())
        .then(data => {
            if(data.id){
                toast.success("Flash editado com sucesso!")
            }
            else{
                toast.error("Erro ao editar flash")
            }
        })

        await props.atualizarFlashs()
    }

    return (
        <>
        <Toaster/>
        <Dialog>
                <DialogTrigger asChild className="ml-2">
                    <Button variant="outline">Editar</Button>
                </DialogTrigger>
                <DialogContent className="sm:max-w-[425px]">
                    <DialogHeader>
                    <DialogTitle>Editar flash</DialogTitle>
                    <DialogDescription>
                        Faça alterações em seu flash aqui. Clique em salvar quando terminar.
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
                    <Button onClick={editar}>Editar</Button>
                    </DialogFooter>
                </DialogContent>
            </Dialog>
        </>
    )
}