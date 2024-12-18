import { Input } from "@/components/ui/input"
import { Button } from "./components/ui/button"

export default function FiltrarCards(props){

    function filtrar(){
        if(props.search.length > 0){
            fetch(`https://localhost:7158/findbyquestioncard?question=${props.search}`, {
                method: "GET",
                headers: {
                    "Content-Type": "application/json",
                }
            })
            .then(response => response.json())
            .then(data => {
                if(data.length > 0){
                    props.setCards(data)
                }
            })
            .catch(e => {
                props.setCards([])
            })
                
        }
        else{
            props.atualizarCards()
        }
    }

    return(
        <>
            <div class="flex w-72">
                <div className="w-60">
                <Input type="text" value={props.search} placeholder="Digite a pergunta" onChange={(e) =>props.setSearch(e.target.value)}/>
                </div>
                <div className="ml-2">
                    <Button onClick={filtrar}>OK</Button>
                </div>
            </div>
        </>
    )
}