import { useEffect, useState } from "react"
import AdicionarFlash from "./adicionarflash"
import CarregarFlashs from "./carregarflashs"
import FiltrarFlashs from "./filtrarflashs"

export default function Flashs(){

    const [flashs, setFlashs] = useState([])
    const [flashSearch, setFlashSearch] = useState()
    const [loading, setLoading] = useState()

    useEffect(() => {
        carregarFlashs()
    }, [])

    async function carregarFlashs(){
        setLoading(false)
        await fetch("https://localhost:7158/allflashs", {
            method: "GET",
            headers: {
                "Content-Type" : "application/json",
            }
        })
        .then(response => response.json())
        .then(data => {
            setLoading(true)
            setFlashs(data)
        })
        .catch(e => 
            setLoading(false)
        )
    }

    function atualizarFlashs(){
        setFlashSearch("")
        carregarFlashs()
    }

    return (
        <>
            <div>
                <div className="mt-10 ml-10 mb-10 flex justify-between">
                    <FiltrarFlashs setFlashs={setFlashs} flashSearch={flashSearch} setFlashSearch={setFlashSearch} atualizarFlashs={atualizarFlashs}/>
                    <AdicionarFlash atualizarFlashs={atualizarFlashs}/>
                </div>
                {
                    loading && flashs.length == 0 ? <p className="text-center text-sm font-medium">Sem resultado</p> : <CarregarFlashs flashs={flashs} loading={loading} atualizarFlashs={atualizarFlashs}/>
                }
            </div>
        </>
    )
}