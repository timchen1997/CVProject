   M S B A M L   `   `   `  ����D  @CVProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CVProject.DialogCVProject.Dialog  5   	   '    !CVProject.Dialog.EdgeDetectDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:CVProject.Dialog     5   	   X TXceed.Wpf.Toolkit, Version=3.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  
EdgeDetect��5	   	   $	��325��6   $	��300��6)   ���	#FF363636 � WindowStartupLocation$ CenterScreen=�6L   .��5
      � .+�5   
   	� -   5         	�Name$ 	rbtnSobel��5      $�� ��6)   $
��Left=�64   $��	10,10,0,0q�6O   $	��Top=�6b   6z   	� 5   
   -   5        $ rbtnLaplacian��5      $�� ��6-   $
��Left=�68   $��	10,49,0,0q�6S   $	��Top=�6f   6~   	� 5   
   -   5        $ 	rbtnCanny��5      $�� ��6)   $
��Left=�64   $��
10,129,0,0q�6O   $	��Top=�6c   6{   �� 5   
   -   5         ��Name$ 	gboxSobel��5      $��Sobel��6&   $
��Left=�65   $��	36,10,0,0q�6P   $	��Top=�6c   $	��246��6{   $��24��6�   �� 5   
   -   5        $ gboxLaplacian��5      $��	Laplacian��6*   $
��Left=�6=   $��	36,49,0,0q�6X   $	��Top=�6k   $	��246��6�   $��66��6�   .��5      � .+�5      �� -   5         ��Name$ label��5      $
��Mode��6'   $
��Left=�66   $��17��6Q   $��	10,13,0,0q�6]   $	��Top=�6p   �� 5      -   5         ��Name$ cboxMode��5      $
��Left=�6-   $��	49,10,0,0q�6H   $	��Top=�6[   $	��120��6s    �� SelectedIndex$ 0��6   .@�5      �� $��4-Link��6   �� 5      $��8-Link��6   5      5      5      �� 5   
   -   5        $ 	gboxCanny��5      $��Canny��6&   $
��Left=�65   $��
36,128,0,0q�6P   $	��Top=�6d   $	��246��6|   $	��130��6�   $��2��6�   .��5      � .+�5      �� $��Gauss Kernel Size��6   $
��Left=�64   $��17��6O   $��	10,13,0,0q�6[   $	��Top=�6n   �� 5      -	   5        $ 	cboxKSize��5      $
��Left=�6.   $	��Top=�6J   $��76��6b   $ 0��6m   $��
127,10,0,0q�6   .@�5      �� $��3��6   �� 5      $��5��6   �� 5      $��7��6   5       �� 5!      $��	Threshold��6   $
��Left=�6,   $��17��6G   $��	10,52,0,0q�6S   $	��Top=�6f   #  Xceed.Wpf.Toolkit.RangeSlider  5"      -
   5        $��TSlider��5"   #   $
��Left=�62   $��	67,36,0,0q�6M   $	��Top=�6`   $	��136��6x      Maximum$	 255Q�6�      
LowerValue$ 30Q�6�   	   HigherValue$	 80Q�6�   
   IsSnapToTickEnabled
 . 6�   %  Xceed.Wpf.Toolkit.DecimalUpDown  5#      -   5        $��l��5#   %   $
��Left=�6.   $��	78,61,0,0q�6I   $	��Top=�6\   $��55��6t   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Minimum$ 0X�6�      Maximum$	 255X�6�      Value 6   ��  �� ElementName$ TSlider�� �� Path$ 
LowerValue�6�     5$      -   5        $��r��5$   %   $
��Left=�6.   $��
148,61,0,0q�6I   $	��Top=�6]   $��55��6u   $ 0X�6�   $	 255X�6�    6�   �� $ TSlider��$ HigherValue�6�   5%      5&      �� 5'   
   -   5         ��Name$ btnOK��5'      $��OK��6    $
��Left=�6-   $��127,267,0,0q�6H   $	��Top=�6]   $��75��6u   6�   �� 5(   
   -   5        $ 	btnCancel��5(      $��Cancel��6$   $
��Left=�65   $��207,267,0,0q�6P   $	��Top=�6e   $��75��6}   6�   5+      5,      