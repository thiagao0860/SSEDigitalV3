   M S B A M L   `   `   `  ����G  CSSEDigitalV3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:SSEDigitalV3.AccountFeaturesSSEDigitalV3.AccountFeatures  5   	   ,    &SSEDigitalV3.AccountFeatures.LoginForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:SSEDigitalV3.AccountFeatures     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  	LoginForm��5	   	   $��476.659��6   $��296.682��6,    � Icon$ iconeSC.ico��6<    � 
ResizeMode$ NoResize=�6O   .��5
      � ���	#FFE7E7E7 � RowDefinitions 5   
   �� 5      $
��124* �6   �� 5      $	��75* �6   �� 5      $	��25* �6   .+�5   
   �� $��50q�6   $
��auto��6   $��0��6)   $ ��ICONE chefe SOUZA CRUZ.png��66   � 5   
   $��20q�6   $��1��6   
������� � ColumnDefinitions 5      �� 5      $��1* �6#   �� 5      $��4* �6#    5      �� 5      $��1* �6    �� 5      $��2 �6    �� 5      $��1* �6    .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  $��0��6&   $��0��63      Kind$ Account=�6C   $
��auto��6R   $��10q�6_   $��20��6k   $��Center=�6w   $��Center=�6�   ���	#FF8282826�     5      $��2��6&   $��0��63   $	 Key=�6C   $
��auto��6N   $��10q�6[   $��20��6g   $��Center=�6s   $��Center=�6�   ���	#FF8282826�   �� 5      -   5         ��Name$ textBoxMatricula��5      $��1��60   $��10q�6@   $��0��6L   $��Center=�6Y   $��	Matricula��6t   6�   G� 5      -   5         G�Name$ textBoxSenha��5      $��1��60   $��10q�6@   $��2��6L   $��Center=�6Y    G� Password$ --------��6�   �� 5      $
��10,0q�6   $��1��6&   $��2��63   5       � 5!   
   $��10q�6   $��2��6    5"      �� 5#      $��1* �6#   �� 5$      $��1* �6#   .+�5&      �� -   5        $��Entrar��5&      $��1��6&   $
��10,0q�66   ���	#FFFFD7006[   �� 5'      -   5        $��Recuperar Senha��5'      $��0��6/   $
��10,0q�6?   ���	#FF050034
�������6w   5)      5,      5-      