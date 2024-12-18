import {
    Table,
    TableBody,
    TableCaption,
    TableCell,
    TableFooter,
    TableHead,
    TableHeader,
    TableRow,
} from "@/components/ui/table"

import ExcluirFlash from "./excluirflash"
import EditarFlash from "./editarflash"

export default function CarregarFlashs(props){
    return(
        <>
            {
                <div className="p-10">
                    <Table>
                        <TableCaption>Uma lista de flash.</TableCaption>
                        <TableHeader>
                        <TableRow>
                            <TableHead className="w-[100px]">Código</TableHead>
                            <TableHead>Nome</TableHead>
                            <TableHead>Segundos</TableHead>
                            <TableHead className="text-right">Ações</TableHead>
                        </TableRow>
                        </TableHeader>
                        <TableBody>
                        {
                            props.flashs.map((item) => {
                                return (
                                    <TableRow key={item.id}>
                                        <TableCell className="font-medium">{item.id}</TableCell>
                                        <TableCell>{item.nome}</TableCell>
                                        <TableCell>{item.segundos}</TableCell>
                                        <TableCell className="text-right">
                                            <ExcluirFlash excluir={item} atualizarFlashs={props.atualizarFlashs}/>
                                            <EditarFlash editar={item} atualizarFlashs={props.atualizarFlashs}/>
                                        </TableCell>
                                    </TableRow>
                                )
                            })
                        }
                        </TableBody>
                        <TableFooter>
                        <TableRow>
                            <TableCell colSpan={3}>Total</TableCell>
                            <TableCell className="text-right">{props.flashs.length}</TableCell>
                        </TableRow>
                        </TableFooter>
                    </Table>
                </div> 
            }
        </>
    )
}