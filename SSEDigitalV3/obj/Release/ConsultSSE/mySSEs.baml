   M S B A M L   `   `   `  ���� G  CSSEDigitalV3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:SSEDigitalV3.ConsultSSESSEDigitalV3.ConsultSSE  $    SSEDigitalV3.ConsultSSE.mySSEs   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  1local%clr-namespace:SSEDigitalV3.ConsultSSE    � Title$  Consultar Minhas SSE��$��709.2��$��1001.6�����	#FF050034.��� $��10q� � ColumnDefinitions ��  � RowDefinitions �� $��85 ��� $��1* ��� $��50 �.+�&   System.Windows.Controls.DataGrid  -     Name$ DataGridSSEs��$��10,10,10.2,12.2q�$��1��   CanUserAddRows .     
IsReadOnly .    AutoGenerateColumns .  
���   �
�������   AlternatingRowBackground �	#FFCDCDCD   HorizontalGridLinesBrush �	#FFC3C3C3	   VerticalGridLinesBrush	 �	#FFC3C3C3
   Columns
 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    CellTemplate �� .R�#  MaterialDesignThemes.Wpf.Card  -    � Cursor$
 Hand��.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Edit=�$��Center=�$��Center=�   .  �� .R�  $	 Eye=�$��Center=�$��Center=�
�������0  *System.Windows.Controls.DataGridTextColumn     Header$ Id��1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$ id�  $
 Data�� �� $
 data�  $
 Tipo�� �� $
 tipo�  $ 
Fornecedor�� �� $ 
fornecedor�  $ Descrição�� �� $ description�  $ Ordem�� �� $ ordem�  $ Código�� �� $ codigo�  $ Referência�� �� $ 
referencia�  $ Prazo�� �� $ prazo�  $ 
Prioridade�� �� $ 
prioridade�  $ Valor�� �� $ valor��� $��2�� �� Orientation$ 
Horizontal=�$��RightToLeft=�$��0,0.8,0.2,0.2q�.+��� -   $��Voltar��$��10q�$
��20,5q�$��Center=����	#FFFFD700� $��10,10,10.2,10q� �� $��70 ��� $��1* ��� $��63 ��� $��63 ��� $��62 �.+��� $��0��$��	5,5,7.6,5q�$>��8/SSEDigitalV3;component/Assets/Image/icon-chefe-mini.png��  -   $��9.4,10,10.2,10q�   UniformCornerRadius$ 5Q�$��4�����	#FFFFD700.��  
���   �$ MicrosoftExcel=�$��Center=�$��Center=�$��30��$��30��  -   $��9.4,10,10.2,10q�$ 5Q�$��3�����	#FFFFD700.��  
���   �$ Printer=�$��Center=�$��Center=�$��30��$��30��  -   $��9.4,10,10.2,10q�$ 5Q�$��2�����	#FFFFD700.��  
���   �$ Email=�$��Center=�$��Center=�$��30��$��30���� $��1�� �� Padding$
 20,0q�$��0q�$
��Wrap=�$��Relatório de SSEs��$��Center=�$��24(�
�������