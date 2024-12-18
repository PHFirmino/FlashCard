import { Button } from './components/ui/button'
import { Alert, AlertDescription, AlertTitle } from "@/components/ui/alert"

import './quizcard.css'

import { useEffect, useState } from 'react'
import { useParams, useNavigate  } from 'react-router-dom'
import AlertQuiz from './alertquiz';

export default function Quizes(){

    const { id } = useParams()
    const navigate = useNavigate()
    const [loading, setLoading] = useState(false)
    const [idTeste, setIdTeste] = useState(null)
    const [idTesteVoltar, setIdTesteVoltar] = useState(0)

    const [segundos, setSegundos] = useState(null)
    const [posicaoAnterior, setPosicaoAnterior] = useState({})
    const [posicaoSeguinte, setPosicaoSeguinte] = useState({})

    const [posicaoEstouIndo, setPosicaoEstouIndo] = useState({})
    const [pergunta, setPergunta] = useState("")
    const [resposta, setResposta] = useState("")

    const [posicao, setPosicao] = useState(0)
    const [quantidade, setQuantidade] = useState(0)

    const [finalizado, setFinalizado] = useState(false)
    const [resultado, setResultado] = useState()

    useEffect(() => {
        quiz(idTeste)
        removerLocalStorege()
    }, [])

    function quiz(idTesteParam){

        if(idTesteParam != 0){
            fetch(`https://localhost:7158/quiz?idFlashCard=${id}&idTeste=${idTesteParam}`, {
                method: "GET",
                headers: {
                    "Content-Type": "application/json",
                }
            })
            .then(response => response.json())
            .then(data => {
                setPosicaoAnterior(data.posicaoAnterior)
                setPosicaoSeguinte(data.posicaoSeguinte)
                setPosicaoEstouIndo(data.posicaoEstouIndo)

                setPergunta(data.posicaoEstouIndo.card.pergunta)
                setResposta(data.posicaoEstouIndo.card.resposta)

                setPosicao(data.posicao)
                setQuantidade(data.quantidade)

                setIdTeste(data.posicaoSeguinte.id)
                setIdTesteVoltar(data.posicaoAnterior.id)

                if(loading == false){
                    contador(data.posicaoEstouIndo.flash.segundos)
                }

                console.log(data)

                setLoading(true)
            })
        }
    }

    function contador(segundosParametro){
        let segundosDescontar = setInterval(() => {
            if(segundosParametro != 0){
                segundosParametro--
                setSegundos(segundosParametro)
            }
            else if(segundosParametro <= 0){
                pararSegundos(segundosDescontar)
                paraSegundosQuandoFinalizarQuiz(segundosDescontar)
            }
        }, 1000)
    }

    function pararSegundos(segundosDescontar){
        enviar()
        clearInterval(segundosDescontar)
    }

    function paraSegundosQuandoFinalizarQuiz(segundosDescontar){
        clearInterval(segundosDescontar)
    }

    function alterarLocalStorege(id, acao){

        let passou = false

        if(localStorage.getItem("quizAcertos")){
            let acerto = JSON.parse(localStorage.getItem("quizAcertos"))

            acerto.forEach(item => {
                if(item.id == id)
                {
                    if(acao == "acerto"){
                        item.erro = 0
                        item.acerto = 1
    
                        localStorage.removeItem("quizAcertos")
                        localStorage.setItem("quizAcertos", JSON.stringify(acerto))
    
                        passou = true
                    }
                    else{
                        item.erro = 1
                        item.acerto = 0
    
                        localStorage.removeItem("quizAcertos")
                        localStorage.setItem("quizAcertos", JSON.stringify(acerto))
    
                        passou = true
                    }
                }
            })

            if(passou == false && acao == "acerto"){

                let adicionarCardArrayLocalStorege = 
                {
                    "id": id,
                    "acerto" : 1,
                    "erro" : 0
                }
                acerto.push(adicionarCardArrayLocalStorege)

                localStorage.removeItem("quizAcertos")
                localStorage.setItem("quizAcertos", JSON.stringify(acerto))
            }
            else if(passou == false && acao == "erro"){

                let adicionarCardArrayLocalStorege = 
                {
                    "id": id,
                    "acerto" : 0,
                    "erro" : 1
                }
                acerto.push(adicionarCardArrayLocalStorege)

                localStorage.removeItem("quizAcertos")
                localStorage.setItem("quizAcertos", JSON.stringify(acerto))
            }
        }
        else{
            if(acao == "acerto"){
                    let adicionarCardArrayLocalStorege = JSON.stringify([
                        {
                            "id": id,
                            "acerto" : 1,
                            "erro" : 0
                        }
                    
                ])
                localStorage.setItem("quizAcertos", adicionarCardArrayLocalStorege)
            }
            else{
                let adicionarCardArrayLocalStorege = JSON.stringify([
                    {
                        "id": id,
                        "acerto" : 0,
                        "erro" : 1
                    }
                
            ])
            localStorage.setItem("quizAcertos", adicionarCardArrayLocalStorege)
            }
        }

        quiz(idTeste)
    }

    function enviar(){
        let acerto = JSON.parse(localStorage.getItem("quizAcertos"))
        let qntAcerto = 0
        let qntErro = 0

        if(localStorage.getItem("quizAcertos")  && acerto.length > 0){
            acerto.forEach(item => {
                if(item.acerto == 1){
                    qntAcerto++
                }
    
                if(item.erro == 1){
                    qntErro++
                }
            })
        }

        fetch("https://localhost:7158/finalizar", {
            method : "POST",
            headers : {
                "Content-Type" : "application/json",
            },
            body : JSON.stringify({
                "idFlashCard": id,
                "acertos": qntAcerto,
                "erros": qntErro
            })
        })
        .then(response => response.json())
        .then(data => {
            console.log(data)
            setFinalizado(true)
            setResultado(data)
            removerLocalStorege()
        })
    }

    function removerLocalStorege(){
        if(localStorage.getItem("quizAcertos")){
            localStorage.removeItem("quizAcertos")
        }
    }


    return(
        <>
            <div className='d flex justify-around mt-10'>
                <div>
                    <p className='text-lg'>{posicao}/{quantidade}</p>
                </div>
                <div>
                    {
                        segundos != 0 ? <p className='text-lg'>{segundos}</p> : <AlertQuiz titulo="O tempo acabou!" texto="Você não enviou o resultado" tipo="tempo"/>
                    }
                </div>
                <div className='flex'>
                    {
                        posicaoAnterior.flashCard == null ? "" :  <Button className="w-32 h-10"  onClick={() => quiz(idTesteVoltar)}>Voltar</Button>
                    }
                    {
                        posicaoSeguinte.flashCard == null ? <Button className="w-32 h-10 ml-2" onClick={() => enviar()}>Finalizar</Button> : <Button className="w-32 h-10 ml-2" onClick={() => quiz(idTeste)}>Passar</Button>
                    }
                </div>
                {
                    finalizado ? <AlertQuiz titulo="Você finalizou!" resultado={resultado}/> : ""
                }
            </div>
            <div className='flex justify-center'>
                <div>
                    <div class="flex flex-wrap m-5 pl-4">
                        <div class="flashcard-containerr">
                            <div class="flashcard">
                                <div class="questionn shadow-lg">
                            <div class="content">
                                <p class="text-2xl p-6">{pergunta}</p>
                            </div>
                            </div>
                                <div class="answerr shadow-lg">
                                    <div class="content">
                                        <p class="text-2xl p-6">{resposta}</p>
                                    </div>
                                </div>
                            </div>
                        </div>                      
                    </div>
                </div>
            </div>
            <div className='mt-10'>
                <div className='flex justify-center'>
                    <div className='w-96'>
                        <Button className="w-52 h-20 text-xl bg-red-600" onClick={() => alterarLocalStorege(posicaoEstouIndo.card.id, "erro")}>Errei</Button>
                    </div>
                    <div>
                        <Button className="w-52 h-20 text-xl bg-green-600" onClick={() => alterarLocalStorege(posicaoEstouIndo.card.id, "acerto")}>Acertei</Button>
                    </div>
                </div>
            </div>
        </>
    )
}