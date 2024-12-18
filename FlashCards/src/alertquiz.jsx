import { Alert, AlertDescription, AlertTitle } from "@/components/ui/alert"
import { Button } from './components/ui/button'
import { useNavigate  } from 'react-router-dom'

export default function AlertQuiz(props){
    const navigate = useNavigate()

    return (
        <>
            <Alert className="fixed inset-0 z-50 bg-black/80 data-[state=open]:animate-in data-[state=closed]:animate-out data-[state=closed]:fade-out-0 data-[state=open]:fade-in-0">
                <Alert className="fixed left-[50%] top-[50%] z-50 grid w-full max-w-lg translate-x-[-50%] translate-y-[-50%] gap-4 border border-zinc-200 bg-white p-6 shadow-lg duration-200 data-[state=open]:animate-in data-[state=closed]:animate-out data-[state=closed]:fade-out-0 data-[state=open]:fade-in-0 data-[state=closed]:zoom-out-95 data-[state=open]:zoom-in-95 data-[state=closed]:slide-out-to-left-1/2 data-[state=closed]:slide-out-to-top-[48%] data-[state=open]:slide-in-from-left-1/2 data-[state=open]:slide-in-from-top-[48%] sm:rounded-lg dark:border-zinc-800 dark:bg-zinc-950">
                    <AlertTitle>{props.titulo}</AlertTitle>
                    <AlertDescription>
                        {props.tipo == "tempo" ? props.texto : 
                            <>
                            <div>
                                <span className="text-green-600">Acertos: </span>
                                <span className="text-green-600">{props.resultado.acertos}</span>
                            </div>
                            <div className="mt-3 mb-3">
                                <span className="text-red-600">Erros: </span>
                                <span className="text-red-600">{props.resultado.erros}</span>
                            </div>
                            <div>
                                <span>Não Respondidas: </span>
                                <span>{props.resultado.naoRespondidas}</span>
                            </div>
                            </>
                        }
                    </AlertDescription>
                    {
                        props.tipo == "tempo" ? "" : <Button onClick={() =>  navigate("/")}>Retornar</Button>
                    }
                </Alert>
            </Alert>
        </>
    )
}