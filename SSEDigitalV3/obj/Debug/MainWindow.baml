   M S B A M L   `   `   `  ����G  CSSEDigitalV3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SSEDigitalV3SSEDigitalV3  5   	       SSEDigitalV3.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:SSEDigitalV3     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  
MainWindow��5	   	   $��469.2��6   $��755.2��6+    � WindowStyle$
 None=�69   ���	#FF050034 � AllowsTransparency . $y�Visible=�6}    � WindowStartupLocation$ CenterScreen=�6�    � Icon$0 *pack://siteoforigin:,,,/solidsouzaicon.eps��6�   .��5
      � $��Stretch=�6   $
��auto��6)   $��0,0,0,0q�67   $��Stretch=�6H   $
��auto��6d    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��117* �6   �� 5      $
��257* �6   .+�5   
   �� $��25q�6   $-��'Assets/Image/ICONE chefe SOUZA CRUZ.png��6   �� 5   
   $��2��6   
�������$��5��64   $��	50,0,50,0q�6?   $	��Top=�6S   $��1��6k    �� RadiusY$	 2.5��6x    �� RadiusX$	 2.5��6�   �� 5   
   $��2��6   	 �� Orientation$	 Vertical=�6%   $��20q�6<   .+�5      �� -   5        
 ��Name$
 labelTitulo��5      $��Ola, Thiago��6)   $��
10,10,0,20q�5      $
��Left=�5      $
��auto��5      $
��auto��6   $��25(�5      
�������6   �� 5      -   5        $
 labelConectAss��5      $+��%Conectado como: Thiago de Souza Alves��6,   $��10,0,0,0q�5      $
��Left=�6"   $
��auto��5      $
��auto��6   
 J� Uid$ LabelNomeCompleto��5      
�������5       �� 5"      -   5        $
 labelMatricula��5"      $��Matricula: 10039895��6,   $��10,0,0,0q�5#      $
��Left=�6"   $
��auto��5$      $
��auto��6   
�������5%      �� 5'      -   5        $
 
labelRamal��5'      $��Ramal : 8888��6(   $��10,0,0,0q�5(      $
��Left=�6"   $
��auto��5)      $
��auto��6   
�������5*      5,      �� 5-   
   $��1��6   $��20q�6"   $��2��6.   $	 
Horizontal=�6B   .+�5.      #  MaterialDesignThemes.Wpf.Card  -   5        $	��140��5.   "   $��20q�6.   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�6:      UniformCornerRadius$ 10Q�5/   "   ���#FFD700 � Cursor$
 Hand��50   L   .��51      �� $	 Vertical=�6   $��20q�64   .+�52      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ PlusBox=�6.   $��75��6=   $
��auto��6I   $��Center=�6V   �� 53      
���   �$
��Wrap=�63    �� TextAlignment$ Center=�6G   
Nova SSE6h   54      55        56      -   5        $	��140��56   "   $��20q�6.   $ Depth3=�6:   $ 10Q�57   "   ���#FFD700$
 Hand��58   L   .��59      �� $	 Vertical=�6   $��20q�64   .+�5:        $ FileDocument=�6.   $��75��6B   $
��auto��6N   $��Center=�6[   �� 5;      
���   �$
��Wrap=�63   $ Center=�6G   Consultar Minhas SSEs6u   5<      5=        5>      -   5        $	��140��5>   "   $��20q�6.   $ Depth3=�6:   $ 10Q�5?   "   ���#FFD700$
 Hand��5@   L   .��5A      �� $	 Vertical=�6   $��20q�64   .+�5B        $ 
AccountCog=�6.   $��75��6@   $
��auto��6L   $��Center=�6Y   �� 5C      
���   �$
��Wrap=�63   $ Center=�6G   Alterar Meus Dadas6r   5D      5E        5F      -   5        $	��140��5F   "   $��20q�6.   $ Depth3=�6:   $ 10Q�5G   "   ���#FFD700$
 Hand��5H   L   .��5I      �� $	 Vertical=�6   $��20q�64   .+�5J        $ 	ExitToApp=�6.   $��75��6?   $
��auto��6K   $��Center=�6X   �� 5K      
���   �$
��Wrap=�63   $ Center=�6G   Sair Deste Computador6u   5L      5M      5N        5O   
   -	   5        $��2��5O   "   $ Close=�67   $��20��6D   $
��auto��6P   $��Right=�6]   $��	0,10,10,0q�5P   "   $	��Top=�65   
�������$
 Hand��5Q   O   5R      5S      