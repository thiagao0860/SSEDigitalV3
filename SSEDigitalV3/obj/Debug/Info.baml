   M S B A M L   `   `   `  ����G  CSSEDigitalV3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SSEDigitalV3SSEDigitalV3  5   	       SSEDigitalV3.Info   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   &localclr-namespace:SSEDigitalV3  5   	     � Title$  SSE Digital��5	   	   $	��600��6   $	��400��6*    � 
ResizeMode$ NoResize=�66    � WindowStartupLocation$ CenterScreen=�6L    � Icon$ iconeSC.ico��6q   ���	#FFE7E7E7.��5
      �  � ColumnDefinitions 5   
   �� 5       � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��2 �6   �� 5      $
��1.5* �6   �� 5      $��1* �6   .+�5   
   �� $��1��6   $��10,87.8,9.6,0q�6    $��2��67   $��Center=�6D   $��2��6_   �� 5   
   -   5        $��1��5      ���	#00000000���	#00000000$��0,9.8,-0.4,10.2q�6N   $��Stretch=�5      $��Stretch=�5      .��5      � $��10                   q�6    5      �� 5      $��1* �6'   �� 5      $��3* �6'   .+�5       '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Login=�6*   $��30��67   $��Center=�6C   $
��auto��6^   $��Center=�6k   �� 5!      $��1��6   $
��Left=�6(   $��Center=�6C   $��12(�6^   .��6m   Entrar6u   5"      5#      �� 5$   
   -   5        $��2��5$      ���	#00000000���	#00000000$��0,9.8,-0.4,10.2q�6N   $��Stretch=�5%      $��Stretch=�5&      .��5'      � $��10                   q�6    5)      �� 5*      $��1* �6'   �� 5+      $��3* �6'   .+�5-        $ 
AccountAdd=�6*   $��30��6<   $��Center=�6H   $
��auto��6c   $��Center=�6p   �� 5.      $��1��6   $
��Left=�6(   $��Center=�6C   $��12(�6^   .��6m   Cadastrar-se6{   5/      50      �� 51   
   -   5        $��5��51      ���	#00000000���	#00000000$��0,9.8,-0.4,10.2q�6N   $��Stretch=�52      $��Stretch=�53      .��54      � $��10                   q�6    56      �� 57      $��1* �6'   �� 58      $��3* �6'   .+�5:        $ 	Incognito=�6*   $��30��6;   $��Center=�6G   $
��auto��6b   $��Center=�6o   �� 5;      $��1��6   $
��Left=�6(   $��Center=�6C   $��12(�6^   .��6l    Versão para Máquina anônima6�   5<      5=      �� 5>   
   $��0��6   .+�5@      �� $��1��6   $��Center=�6%   $��Center=�6B   $��18(�6]   $��20q�6k   .��6w   (&Selecione o Modo de Acesso ao Sistema:6�   5C      �� 5D   
   $��4��6   .+�5F      �� $
��Wrap=�6   $��1��6-   $��Center=�6=   $��Center=�6Z   $��18(�6u   $��10q�6�    �� TextAlignment$ Center=�6�   sqVocê ainda pode inserir seus dados manualmente, (isso não impede que caturemos informações sobre seu acesso):6  �� 5G      -   5         ��Name$ 	checkBox1��5G      $6��0Salvar minha resposta e não perguntar novamente��6*   $��30,20q�6d   5I      5J      5K      