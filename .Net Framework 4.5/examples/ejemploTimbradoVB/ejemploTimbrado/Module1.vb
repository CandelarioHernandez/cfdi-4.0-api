Imports System.Net
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Module Module1

    Sub Main()
        Dim xml As String = "<?xml version='1.0' encoding='UTF-8'?><cfdi:Comprobante xmlns:cfdi='http://www.sat.gob.mx/cfd/3' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xsi:schemaLocation='http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv33.xsd' Version='3.3' Serie='F' Folio='12822' Fecha='2020-11-09T23:15:39' Sello='XRfexo3WjlPJbT/wSe1uQznRS181RSvwmCFl11ItHMyZF+YhqDJWbqOMZcqNlItpUoTMCigZilBx1dyK3Hj4yLl0l3xMhWniUC0ogRQqGZzoiPdvKedbgSJh5bkJ6YSjDO4FAA8xTFTugvQXilBEgfkuSHmRoe26PACiyT41h3tTkwBKvI5qlEFHc5Urzu/cmfSS8K8S3t3BS3xf0mYkm2y606tr1CuOizZC9O5ttYPX4rdzTwYe4RnUAsAHOuGtZ0SPSJxlxM15OQ9JcSgeFePGQ8xSu6UAgPwXlybBdpG7Wba0I8lV9MNX3UMZI4jz2DWNcrs7mJeCvLxFtMwNfA==' FormaPago='01' NoCertificado='30001000000300023708' Certificado='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' CondicionesDePago='Inmediato' SubTotal='10.00' Moneda='MXN' Total='11.60' TipoDeComprobante='I' MetodoPago='PUE' LugarExpedicion='86000'><cfdi:Emisor Rfc='AAA010101AAA' Nombre='CLIENTE DE PRUEBA' RegimenFiscal='625' /><cfdi:Receptor Rfc='PEJI7010035T6' Nombre='Perez Iscariote Judas Fiscal' UsoCFDI='G01' /><cfdi:Conceptos><cfdi:Concepto ClaveProdServ='60102401' NoIdentificacion='B2B99842B3' Cantidad='1' ClaveUnidad='H87' Unidad='pza' Descripcion='Concepto prueba' ValorUnitario='10.00' Importe='10.00'><cfdi:Impuestos><cfdi:Traslados><cfdi:Traslado Base='10.00' Impuesto='002' TipoFactor='Tasa' TasaOCuota='0.160000' Importe='1.60' /></cfdi:Traslados></cfdi:Impuestos></cfdi:Concepto></cfdi:Conceptos><cfdi:Impuestos TotalImpuestosTrasladados='1.60'><cfdi:Traslados><cfdi:Traslado Impuesto='002' TipoFactor='Tasa' TasaOCuota='0.160000' Importe='1.60' /></cfdi:Traslados></cfdi:Impuestos><cfdi:Complemento></cfdi:Complemento><cfdi:Addenda><induxsoft:addenda xsi:schemaLocation='http://dev.induxsoft.net/xsd/cfdi/addendas/addendabasica.xsd http://dev.induxsoft.net/xsd/cfdi/addendas/addendabasica.xsd' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:induxsoft='http://dev.induxsoft.net/xsd/cfdi/addendas/addendabasica.xsd'><induxsoft:etiqueta titulo='Total con letras' id='NumLetraTotalDocumento' valor='(ONCE 60/100 PESO MEXICANO)' /><induxsoft:etiqueta titulo='Dirección del receptor' id='DirReceptor' valor='Centro' valor3='29000' valor2='Central Nte,Tuxtla Gutiérrez,Chiapas,México,#300' /><induxsoft:etiqueta titulo='Ubicación del domicilio del receptor' id='LugarReceptor' valor3='México' valor2='Chiapas' /><induxsoft:etiqueta titulo='Domicilio de expedición' id='DirEmisor' valor3='CENTRO' valor2='Centro [Villahermosa] ,Tabasco,México' /></induxsoft:addenda></cfdi:Addenda></cfdi:Comprobante>"

        'Se crea el Objeto que realizará la solicitud REST
        Dim webClient As New WebClient()
        Try
            'Variable de tipo dictionary para guardar los datos
            Dim JSonData As Dictionary(Of String, Object)
            JSonData = New Dictionary(Of String, Object)
            JSonData.Add("xml", Convert.ToBase64String(Encoding.UTF8.GetBytes(xml))) 'xml en formato base64
            JSonData.Add("cti", "xipova")
            JSonData.Add("pwd", "123456")
            JSonData.Add("nb64", False)
            Dim URL As String = "https://factudesk.api.induxsoft.net/comprobantes/timbrar/" 'end point que se dirigirá la petición
            'Se convierte el dictionary que representa los datos en un String
            Dim strJSON As String = JsonConvert.SerializeObject(JSonData, Formatting.None)
            'El String con el JSON se convierte a un arreglo de Bytes
            Dim reqString() As Byte = Encoding.Default.GetBytes(strJSON)
            'Se realiza la solicitud por el verbo POST enviando el JSON representado en Bytes
            Dim resByte As Byte() = webClient.UploadData(URL, "post", reqString)
            'Se convierte la respuesta que es un arreglo de Bytes a un String
            Dim resString As String = Encoding.Default.GetString(resByte)
            'Se libera el Objeto de la conexión
            webClient.Dispose()
            'Se retorna la respuestaString en formato JObject (json)
            Dim res As JObject = JsonConvert.DeserializeObject(Of JObject)(resString)

            'condición para saber si la respuesta del servicio fue false
            If Not (Convert.ToBoolean(res("success"))) Then
                Throw New Exception(res("message")) 'Muestra el mensaje en caso de error
            End If
            'crea una ruta en donde guardar el xml ya timbrado
            Dim ruta As String = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), res("data")("uuid").ToString() + ".xml")
            'crea el archivo xml 
            System.IO.File.WriteAllText(ruta, Encoding.UTF8.GetString(Convert.FromBase64String(res("data")("xml"))))
            'abre el xml generado
            System.Diagnostics.Process.Start(ruta)

            Console.WriteLine("El UUID del comprobante timbrado es: " + res("data")("uuid").ToString())
            Console.WriteLine("El CFDI está en: " + ruta)
        Catch ex As Exception
            'Se imprime en consola el error generado
            Console.WriteLine("E R R O R !!!")
            Console.WriteLine(ex.Message)
        End Try
        Console.WriteLine("")
        Console.WriteLine("Presione ENTER para terminar")
        Console.ReadLine()
    End Sub

End Module
