function selectPaciente(values)
{
    var codigo = values[0];
    var paciente = values[1];
    var email = values[2];
    var telefone = values[3];  
    lblPacienteNome.SetText(paciente);
    lblTelefonePaciente.SetText(telefone);
    //Seta elemento hidden com o id do paciente    
    var idPaciente = document.getElementById('idPaciente');
    idPaciente.value = codigo;    
    //limpa os dados do popup e grid para fechar o popup
    txtCpf.SetText('');
    popPacientes.Hide();
}

function validaDadosGridRow(values)
{
    var situacao = values[0];
    var idConvenio = cmbConvenios.GetValue();
    var categoria = cmbCategoria.GetValue();
    var hora = values[1];
    var paciente = values[2];
    var telefone = values[3];
    var convenio = values[4];
    var servico = values[5];
    var obs = values[6];
    var url;
    var dtConsulta = document.getElementById("hdnDataConsulta");
    var idMedico = document.getElementById("hdnIdMedico");
    var idServico = cmbServicos.GetSelectedItem().value;
    
    //Existe paciente agendado
    if(paciente != '' && paciente != 'Horário Bloqueado' && telefone != '' && situacao != 'Atendido')
    {
        url = 'ManterConsultaAgenda.aspx?exists=true&idCategoria='+categoria+'&idConvenio='+idConvenio +'&idServico='+idServico+'&dtConsulta='+dtConsulta.value+'&idMedico='+idMedico.value+'&hora='+hora+'&paciente='+paciente+'&telefone='+telefone+'&convenio='+convenio+'&servico='+servico+'&obs='+obs;
        abrirDetalhesAgendamento(url,'',800,600,'no');    
    }else if(paciente == '' && paciente != 'Horário Bloqueado' && situacao != 'Atendido')
    {
        //Não existe paciente agendado
        url = 'ManterConsultaAgenda.aspx?new=true&idCategoria='+categoria+'&idConvenio='+idConvenio +'&idServico='+idServico+'&dtConsulta='+dtConsulta.value+'&idMedico='+idMedico.value+'&hora='+hora;
        abrirDetalhesAgendamento(url,'',800,600,'no');
    }else if(paciente == 'Horário Bloqueado' && situacao != 'Atendido')
    {
        url = 'HorarioBloqueado.htm';
        abrirDetalhesAgendamento(url,'',800,600,'no');    
    }else if(situacao == 'Atendido')
    {
        url = 'AcessoNaoPermitido.htm';
        abrirDetalhesAgendamento(url,'',800,600,'no');        
    }
        
}

function abrirDetalhesAgendamento(pagina,nome,w,h,scroll){
	LeftPosition = (screen.width) ? (screen.width-w)/2 : 0;
	TopPosition = (screen.height) ? (screen.height-h)/2 : 0;
	settings = 'height='+h+',width='+w+',top='+TopPosition+',left='+LeftPosition+',scrollbars='+scroll+',resizable=no'
	window.open(pagina,nome,settings);
}

function popup_Shown(s, e) {
    cbpObservacoes.AdjustControl();
}

function OnMoreInfoClick(element, key) {
    cbpObservacoes.PerformCallback(key);
    popObservacoes.ShowAtElement(element);
}

function AbrirWindowPadrao(url)
{
    window.open(url,"","width=900, height=600, status=0, toolbar=0, menubar=0, resizable=0, scrollbars=0");
}

function validarCPF(cpf)
{
    var filtro = /^\d{3}.\d{3}.\d{3}-\d{2}$/i;
    if(!filtro.test(cpf))
    {
        window.alert("CPF inválido. Tente novamente.");
	    return false;
    }
   
   cpf = remove(cpf, ".");
   cpf = remove(cpf, "-");
    
    if(cpf.length != 11 || cpf == "00000000000" || cpf == "11111111111" ||
	    cpf == "22222222222" || cpf == "33333333333" || cpf == "44444444444" ||
	    cpf == "55555555555" || cpf == "66666666666" || cpf == "77777777777" ||
	    cpf == "88888888888" || cpf == "99999999999"){
	    window.alert("CPF inválido. Tente novamente.");
	    return false;
    }

   soma = 0;
   
   for(i = 0; i < 9; i++)
   	    soma += parseInt(cpf.charAt(i)) * (10 - i);
        resto = 11 - (soma % 11);
   
   if(resto == 10 || resto == 11)
	    resto = 0;
	    
   if(resto != parseInt(cpf.charAt(9)))
   {
	    window.alert("CPF inválido. Tente novamente.");
	    return false;
   }
   
   soma = 0;
   
   for(i = 0; i < 10; i ++)
	    soma += parseInt(cpf.charAt(i)) * (11 - i);
        resto = 11 - (soma % 11);
   
   if(resto == 10 || resto == 11)
	    resto = 0;
   
   if(resto != parseInt(cpf.charAt(10))){
        window.alert("CPF inválido. Tente novamente.");
	    return false;
   }
   
   return true;
 }
 
 function remove(str, sub) {
    
    i = str.indexOf(sub);
    r = "";
    
    if (i == -1) return str;
        r += str.substring(0,i) + remove(str.substring(i + sub.length), sub);
    
    return r;
 }