for /L %%I in (0,1,9) do fc /U odata_xml_%%I.txt odata_xml_%%I.model.txt 
pause
